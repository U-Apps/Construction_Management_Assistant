using ConstructionManagementAssistant.Core.DTOs.Auth;
using ConstructionManagementAssistant.Core.Helper;
using ConstructionManagementAssistant.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ConstructionManagementAssistant.EF.Repositories
{
    /// <summary>
    /// Provides authentication and user management services.
    /// </summary>
    public class AuthRepository : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IOptions<JWT> _jwtOptions;
        private readonly IEmailService _emailService;

        public AuthRepository(UserManager<AppUser> userManager, IOptions<JWT> jwtOptions, IEmailService emailService)
        {
            _emailService = emailService;
            _userManager = userManager;
            _jwtOptions = jwtOptions;
        }

        /// <inheritdoc />
        public async Task<BaseResponse<AuthResponse>> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return new BaseResponse<AuthResponse>
                {
                    Data = null,
                    Errors = null,
                    Message = "Email or password is wrong ... please try again",
                    Success = false,
                };
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
                return new BaseResponse<AuthResponse>
                {
                    Data = null,
                    Errors = null,
                    Message = "Email is not confirmed",
                    Success = false,

                };


            return new BaseResponse<AuthResponse>
            {
                Data = new AuthResponse
                {
                    Name = user.Name,
                    Email = user.Email,
                    UserName = user.UserName,
                    AccessToken = await GenerateJwtToken(user),
                    RefereshToken = user.RefereshTokens?.LastOrDefault(t => t.IsActive)?.Token,
                    RefreshTokenExpiration = user.RefereshTokens?.LastOrDefault(t => t.IsActive)?.ExpiresOn ?? DateTime.UtcNow
                },
                Errors = null,
                Message = "User login successfully",
                Success = true,
            };
        }

        /// <inheritdoc />
        public async Task<BaseResponse<AuthResponse>> RegisterAsync(RegisterDto registerDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                return new BaseResponse<AuthResponse>
                {
                    Data = null,
                    Errors = new List<string> { "Email already exists." },
                    Message = "Registration failed, email already exists",
                    Success = false,
                };
            }

            var user = new AppUser
            {
                Name = registerDto.Name,
                PhoneNumber = registerDto.PhoneNumber,
                UserName = registerDto.Email.Split('@')[0],
                Email = registerDto.Email,
                PhoneNumberConfirmed = true,
                RefereshTokens = new List<RefreshToken>()
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                var errorMessages = result.Errors.Select(x => x.Description).ToList();
                return new BaseResponse<AuthResponse>
                {
                    Data = null,
                    Errors = errorMessages,
                    Message = "Invalid registration",
                    Success = false,
                };
            }

            // Assign default user role (Admin)
            var roleResult = await _userManager.AddToRoleAsync(user, SystemRole.Admin.ToString());
            if (!roleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                return new BaseResponse<AuthResponse>
                {
                    Data = null,
                    Errors = roleResult.Errors.Select(x => x.Description).ToList(),
                    Message = "Could not assign role to this user",
                    Success = false,
                };
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = $"https://yourfrontend.com/confirm-email?userId={user.Id}&token={Uri.EscapeDataString(token)}";

            var html = $"<p>Please confirm your email by clicking <a href='{confirmationLink}'>here</a>.</p>";
            await _emailService.SendEmailAsync(user.Email, "Confirm your email", html);

            var refreshToken = GenerateRefreshToken();
            user.RefereshTokens.Add(refreshToken);
            await _userManager.UpdateAsync(user);

            return new BaseResponse<AuthResponse>
            {
                Data = new AuthResponse
                {
                    Name = registerDto.Name,
                    Email = registerDto.Email,
                    UserName = user.UserName,
                    AccessToken = await GenerateJwtToken(user),
                    RefereshToken = refreshToken.Token,
                    RefreshTokenExpiration = refreshToken.ExpiresOn
                },
                Message = "Ur account creaetd succffully, check ur email for confirmation",
                Success = true,
            };
        }


        public async Task<BaseResponse<string>> ForgotPasswordAsync(ForgotPasswordDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return new BaseResponse<string> { Success = false, Message = "User not found" };





            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = $"https://yourfrontend.com/reset-password?email={dto.Email}&token={Uri.EscapeDataString(token)}";

            var html = $"<p>Reset your password by clicking <a href='{resetLink}'>here</a>.</p>";
            await _emailService.SendEmailAsync(dto.Email, "Reset Password", html);






            return new BaseResponse<string> { Success = true, Message = "check your email please to reset the password" }; ;
        }
        public async Task<BaseResponse<string>> ResetPasswordAsync(ResetPasswordDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "User not found",

                };
            }

            var result = await _userManager.ResetPasswordAsync(user, dto.Token, dto.NewPassword);
            if (!result.Succeeded)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "Password reset failed.",
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }

            return new BaseResponse<string>
            {
                Success = true,
                Message = "Password reset successfully."
            };
        }

        public async Task<BaseResponse<string>> SendConfirmationEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new BaseResponse<string> { Success = false, Message = "User not found" };

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = $"https://constructionmanagementassitantapi.runasp.net/api/v1/auth/confirmEmail?userId={user.Id}&token={Uri.EscapeDataString(token)}";

            var html = $"<p>Please confirm your email by clicking <a href='{confirmationLink}'>here</a>.</p>";
            await _emailService.SendEmailAsync(email, "Confirm your email", html);

            return new BaseResponse<string> { Success = true, Message = "check your email please" }; ;
        }

        public async Task<BaseResponse<string>> ConfirmEmailAsync(ConfirmEmailDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user == null)
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "User not found"
                };

            var decodedToken = Uri.UnescapeDataString(dto.Token);

            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);
            if (!result.Succeeded)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "Email confirmation failed",
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }

            return new BaseResponse<string>
            {
                Success = true,
                Message = "Email confirmed successfully"
            };
        }


        private async Task<string> GenerateJwtToken(AppUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.Name ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? "")
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Value.Issuer,
                audience: _jwtOptions.Value.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtOptions.Value.DurationInMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpiresOn = DateTime.UtcNow.AddDays(_jwtOptions.Value.DurationInDays),
                CreatedOn = DateTime.UtcNow,
            };
        }

        /// <inheritdoc />
        public async Task<BaseResponse<AuthResponse>> RefreshTokenAsync(string token)
        {
            var response = new BaseResponse<AuthResponse>();

            var user = await _userManager.Users
                .Include(u => u.RefereshTokens)
                .SingleOrDefaultAsync(u => u.RefereshTokens.Any(t => t.Token == token));

            if (user == null)
            {
                response.Success = false;
                response.Message = "Invalid Token";
                response.Data = null;
                return response;
            }

            var refreshToken = user.RefereshTokens.SingleOrDefault(t => t.Token == token);

            if (refreshToken == null || !refreshToken.IsActive)
            {
                response.Success = false;
                response.Message = "Inactive or invalid token";
                response.Data = null;
                return response;
            }

            refreshToken.RevokedOn = DateTime.UtcNow;

            var newRefreshToken = GenerateRefreshToken();
            user.RefereshTokens.Add(newRefreshToken);
            await _userManager.UpdateAsync(user);

            var jwtToken = await GenerateJwtToken(user);

            response.Success = true;
            response.Message = "Token refreshed successfully";
            response.Data = new AuthResponse
            {
                Email = user.Email,
                Name = user.Name,
                UserName = user.UserName,
                AccessToken = jwtToken,
                RefereshToken = newRefreshToken.Token,
                RefreshTokenExpiration = newRefreshToken.ExpiresOn
            };

            return response;
        }



        public Task<BaseResponse<string>> LogoutAsync(ClaimsPrincipal userPrincipal)
        {
            throw new NotImplementedException();
        }


    }
}