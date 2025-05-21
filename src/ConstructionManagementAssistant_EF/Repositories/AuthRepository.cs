using ConstructionManagementAssistant.Core.DTOs.Auth;
using ConstructionManagementAssistant.Core.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ConstructionManagementAssistant.EF.Repositories
{
    public class AuthRepository : IAuthService
    {
        private readonly UserManager<ApplicationIdentity> _userManager;
        private readonly IOptions<JWTSettings> _jwtOptions;
        private readonly IEmailService _emailService;

        public AuthRepository(UserManager<ApplicationIdentity> userManager, IOptions<JWTSettings> jwtOptions, IEmailService emailService)
        {
            _emailService = emailService;
            _userManager = userManager;
            _jwtOptions = jwtOptions;
        }

        public async Task<BaseResponse<ResponseLogin>> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
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
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    Email = user.Email,
                    AccessToken = await GenerateJwtTokenAsync(user),
                    RefreshToken = refreshToken,
                },
                Errors = null,
                Message = "User login successfully",
                Success = true,
            };
        }

        public async Task<BaseResponse<ResponseLogin>> RegisterAsync(RegisterDto registerDto)
        {
            var user = new ApplicationIdentity
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                PhoneNumber = registerDto.PhoneNumber,
                UserName = registerDto.Email.Substring(0, registerDto.Email.IndexOf('@')),
                Email = registerDto.Email,
                PhoneNumberConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                var errorsMassgese = result.Errors.Select(x => x.Description);
                return new BaseResponse<ResponseLogin>
                {
                    Data = null,
                    Errors = errorsMassgese.ToList(),
                    Message = "invalid register",
                    Success = false,
                };
            }
            var roles = await _userManager.AddToRoleAsync(user, registerDto.role.ToString());
            if (!roles.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                return new BaseResponse<ResponseLogin>
                {
                    Data = null,
                    Errors = null,
                    Message = "something wrong ... can not assign role to this user",
                    Success = false,
                };
            }
            return new BaseResponse<ResponseLogin>
            {
                Data = new ResponseLogin
                {
                    firstName = registerDto.FirstName,
                    lastName = registerDto.LastName,
                    Email = registerDto.Email,
                    AccessToken = await GenerateJwtTokenAsync(user)

                },
                Errors = null,
                Message = "User Created successfully",
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

            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = DateTime.MinValue;

            await _userManager.UpdateAsync(user);

            return new BaseResponse<string>
            {
                Success = true,
                Message = "Logged out successfully"
            };
        }
        private async Task<string> GenerateJwtTokenAsync(ApplicationIdentity user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.GivenName, user.FirstName ?? ""),
        new Claim(ClaimTypes.Surname, user.LastName ?? ""),
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

        private string GenerateRefreshToken()
        {
            var randomBytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.Key)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }


    }

}




