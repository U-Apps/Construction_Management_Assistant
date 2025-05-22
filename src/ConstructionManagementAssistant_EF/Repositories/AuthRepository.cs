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

        public AuthRepository(UserManager<AppUser> userManager, IOptions<JWT> jwtOptions)
        {
            _emailService = emailService;
            _userManager = userManager;
            _jwtOptions = jwtOptions;
        }

        /// <inheritdoc />
        public async Task<BaseResponse<ResponseLogin>> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return new BaseResponse<ResponseLogin>
                {
                    Data = null,
                    Errors = null,
                    Message = "Email or password is wrong ... please try again",
                    Success = false,
                };
            if (user.EmailConfirmed == false)
            {
                return new BaseResponse<ResponseLogin>
                {
                    Data = null,
                    Errors = null,
                    Message = "Email is not confirmed",
                    Success = false,

                };
            }
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _userManager.UpdateAsync(user);
            return new BaseResponse<ResponseLogin>
            {
                Data = new ResponseLogin
                {
                    Name = user.Name,
                    Email = user.Email,
                    UserName = user.UserName,
                    Token = await GenerateJwtToken(user),
                    RefereshToken = user.RefereshTokens?.LastOrDefault(t => t.IsActive)?.Token,
                    RefreshTokenExpiration = user.RefereshTokens?.LastOrDefault(t => t.IsActive)?.ExpiresOn ?? DateTime.UtcNow
                },
                Errors = null,
                Message = "User login successfully",
                Success = true,
            };
        }

        /// <inheritdoc />
        public async Task<BaseResponse<ResponseLogin>> RegisterAsync(RegisterDto registerDto)
        {
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
                return new BaseResponse<ResponseLogin>
                {
                    Data = null,
                    Errors = errorMessages,
                    Message = "Invalid registration",
                    Success = false,
                };
            }

            // Assign default user role (not Admin)
            var roleResult = await _userManager.AddToRoleAsync(user, SystemRole.Admin.ToString());
            if (!roleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                return new BaseResponse<ResponseLogin>
                {
                    Data = null,
                    Errors = roleResult.Errors.Select(x => x.Description).ToList(),
                    Message = "Could not assign role to this user",
                    Success = false,
                };
            }

            var refreshToken = GenerateRefreshToken();
            user.RefereshTokens.Add(refreshToken);
            await _userManager.UpdateAsync(user);

            return new BaseResponse<ResponseLogin>
            {
                Data = new ResponseLogin
                {
                    Name = registerDto.Name,
                    Email = registerDto.Email,
                    UserName = user.UserName,
                    Token = await GenerateJwtToken(user),
                    RefereshToken = refreshToken.Token,
                    RefreshTokenExpiration = refreshToken.ExpiresOn
                },
                Message = "User created successfully",
                Success = true,
            };
        }

        /// <inheritdoc />
        public async Task<BaseResponse<string>> ForgotPasswordAsync(ForgotPasswordDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                // Do not reveal if email exists
                return new BaseResponse<string>
                {
                    Success = true,
                    Message = "If the email exists, a reset token has been sent."
                };
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = $"https://yourfrontend.com/reset-password?email={dto.Email}&token={Uri.EscapeDataString(token)}";

            var html = $"<p>Reset your password by clicking <a href='{resetLink}'>here</a>.</p>";
            await _emailService.SendEmailAsync(dto.Email, "Reset Password", html);

        /// <inheritdoc />
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
            var confirmationLink = $"https://yourfrontend.com/confirm-email?userId={user.Id}&token={Uri.EscapeDataString(token)}";

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
        public async Task<BaseResponse<TokenDto>> RefreshTokenAsync(TokenDto dto)
        {
            var principal = GetPrincipalFromExpiredToken(dto.AccessToken);
            var email = principal?.Identity?.Name;

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || user.RefreshToken != dto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                return new BaseResponse<TokenDto>
                {
                    Success = false,
                    Data = null,
                    Errors = null,
                    Message = "Invalid refresh request",
                };

            var newAccessToken = await GenerateJwtTokenAsync(user);
            var newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);

            return new BaseResponse<TokenDto>
            {
                Data = new TokenDto
                {
                    AccessToken = newAccessToken,
                    RefreshToken = newRefreshToken
                },

            };

        }
        public async Task<BaseResponse<string>> LogoutAsync(ClaimsPrincipal userPrincipal)
        {
            var user = await _userManager.GetUserAsync(userPrincipal);
            if (user == null)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "Unauthorized"
                };
            }

        /// <summary>
        /// Generates a JWT token for the specified user.
        /// </summary>
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

        /// <summary>
        /// Generates a new refresh token.
        /// </summary>
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
        public async Task<BaseResponse<ResponseLogin>> RefreshTokenAsync(string token)
        {
            var response = new BaseResponse<ResponseLogin>();

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
            response.Data = new ResponseLogin
            {
                Email = user.Email,
                Name = user.Name,
                UserName = user.UserName,
                Token = jwtToken,
                RefereshToken = newRefreshToken.Token,
                RefreshTokenExpiration = newRefreshToken.ExpiresOn
            };

            return response;
        }
    }
}
