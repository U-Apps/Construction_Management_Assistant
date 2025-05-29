using ConstructionManagementAssistant.Core.Constants;
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
        private readonly ILogger<AuthRepository> _logger;

        public AuthRepository(
            UserManager<AppUser> userManager,
            IOptions<JWT> jwtOptions,
            IEmailService emailService,
            ILogger<AuthRepository> logger)
        {
            _emailService = emailService;
            _userManager = userManager;
            _jwtOptions = jwtOptions;
            _logger = logger;
        }

        public async Task<BaseResponse<AuthResponse>> LoginAsync(LoginDto loginDto)
        {
            _logger.LogInformation("Login attempt for email: {Email}", loginDto.Email);

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                _logger.LogWarning("Login failed for email: {Email}", loginDto.Email);
                return new BaseResponse<AuthResponse>
                {
                    Message = "Email or password is wrong ... please try again",
                    Success = false,
                };
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                _logger.LogWarning("Login failed: email not confirmed for user: {Email}", loginDto.Email);
                return new BaseResponse<AuthResponse>
                {
                    Message = "Email is not confirmed",
                    Success = false
                };
            }

            string RefreshToken = string.Empty;
            DateTime RefreshTokenExpiration;
            if (user.RefreshTokens.Any(t => t.IsActive))
            {
                RefreshToken? activeRefreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);

                RefreshToken = activeRefreshToken.Token;
                RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
            }
            else
            {
                var refreshToken = GenerateRefreshToken();

                RefreshToken = refreshToken.Token;
                RefreshTokenExpiration = refreshToken.ExpiresOn;

                user.RefreshTokens.Add(refreshToken);
                await _userManager.UpdateAsync(user);
            }

            _logger.LogInformation("User {Email} logged in successfully", loginDto.Email);

            return new BaseResponse<AuthResponse>
            {
                Data = new AuthResponse
                {
                    Name = user.Name,
                    Email = user.Email,
                    UserName = user.UserName,
                    AccessToken = await GenerateJwtToken(user),
                    RefereshToken = RefreshToken,
                    RefreshTokenExpiration = RefreshTokenExpiration
                },
                Message = "User login successfully",
                Success = true,
            };
        }

        public async Task<BaseResponse<string>> RegisterAsync(RegisterDto registerDto)
        {
            _logger.LogInformation("Registration attempt for email: {Email}", registerDto.Email);

            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                _logger.LogWarning("Registration failed: email already exists: {Email}", registerDto.Email);
                return new BaseResponse<string>
                {
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
                RefreshTokens = new List<RefreshToken>()
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                var errorMessages = result.Errors.Select(x => x.Description).ToList();
                _logger.LogWarning("Registration failed for email: {Email}. Errors: {Errors}", registerDto.Email, string.Join(", ", errorMessages));
                return new BaseResponse<string>
                {
                    Errors = errorMessages,
                    Message = "Invalid registration",
                    Success = false,
                };
            }

            var roleResult = await _userManager.AddToRoleAsync(user, SystemRole.Admin.ToString());
            if (!roleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);
                _logger.LogWarning("Role assignment failed for user: {Email}. Errors: {Errors}", registerDto.Email, string.Join(", ", roleResult.Errors.Select(x => x.Description)));
                return new BaseResponse<string>
                {
                    Errors = roleResult.Errors.Select(x => x.Description).ToList(),
                    Message = "Could not assign role to this user",
                    Success = false,
                };
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = $"{BaseAddress.Remote}/api/v1/auth/confirmEmail?userId={user.Id}&token={Uri.EscapeDataString(token)}";

            var html = $@"
                <div style='font-family:Segoe UI,Arial,sans-serif;max-width:500px;margin:40px auto;padding:30px;border-radius:10px;background:#f9f9f9;border:1px solid #e0e0e0;'>
                    <h2 style='color:#2d7ff9;'>Welcome to Construction Management Assistant!</h2>
                    <p style='font-size:16px;color:#333;'>Thank you for registering, <b>{user.Name}</b>!</p>
                    <p style='font-size:15px;color:#333;'>Please confirm your email address to activate your account.</p>
                    <a href='{confirmationLink}' style='display:inline-block;margin:20px 0;padding:12px 24px;background:#2d7ff9;color:#fff;text-decoration:none;border-radius:5px;font-size:16px;'>Confirm Email</a>
                    <p style='font-size:13px;color:#888;'>If you did not create an account, you can safely ignore this email.</p>
                </div>
            ";
            await _emailService.SendEmailAsync(user.Email, "Confirm your email", html);

            _logger.LogInformation("Registration successful for email: {Email}", registerDto.Email);

            return new BaseResponse<string> { Success = true, Message = "User added Succfully, check your email please" };
        }

        public async Task<BaseResponse<AuthResponse>> ConfirmEmailAsync(int userId, string token)
        {
            _logger.LogInformation("Email confirmation attempt for userId: {UserId}", userId);

            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                _logger.LogWarning("Email confirmation failed: user not found for userId: {UserId}", userId);
                return new BaseResponse<AuthResponse>
                {
                    Success = false,
                    Message = "User not found"
                };
            }

            var decodedToken = Uri.UnescapeDataString(token);

            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);
            if (!result.Succeeded)
            {
                _logger.LogWarning("Email confirmation failed for userId: {UserId}. Errors: {Errors}", userId, string.Join(", ", result.Errors.Select(e => e.Description)));
                return new BaseResponse<AuthResponse>
                {
                    Success = false,
                    Message = "Email confirmation failed",
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }

            var refreshToken = GenerateRefreshToken();
            user.RefreshTokens.Add(refreshToken);
            await _userManager.UpdateAsync(user);

            _logger.LogInformation("Email confirmed successfully for userId: {UserId}", userId);

            return new BaseResponse<AuthResponse>
            {
                Data = new AuthResponse
                {
                    Name = user.Name,
                    Email = user.Email,
                    UserName = user.UserName,
                    AccessToken = await GenerateJwtToken(user),
                    RefereshToken = refreshToken.Token,
                    RefreshTokenExpiration = refreshToken.ExpiresOn
                },
                Message = "Ur account creaetd succffully, check ur email for confirmation",
                Success = true,
            };
        }

        public async Task<BaseResponse<string>> ForgotPasswordAsync(string email)
        {
            _logger.LogInformation("Forgot password attempt for email: {Email}", email);

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogWarning("Forgot password failed: user not found for email: {Email}", email);
                return new BaseResponse<string> { Success = false, Message = "User not found" };
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = $"https://construction-management-app.vercel.app/reset-password?email={email}&token={Uri.EscapeDataString(token)}";

            var html = $@"
                <div style='font-family:Segoe UI,Arial,sans-serif;max-width:500px;margin:40px auto;padding:30px;border-radius:10px;background:#f9f9f9;border:1px solid #e0e0e0;'>
                    <h2 style='color:#2d7ff9;'>Password Reset Request</h2>
                    <p style='font-size:16px;color:#333;'>We received a request to reset your password. Click the button below to reset it:</p>
                    <a href='{resetLink}' style='display:inline-block;margin:20px 0;padding:12px 24px;background:#2d7ff9;color:#fff;text-decoration:none;border-radius:5px;font-size:16px;'>Reset Password</a>
                    <p style='font-size:13px;color:#888;'>If you did not request a password reset, you can safely ignore this email.</p>
                </div>
            ";
            await _emailService.SendEmailAsync(email, "Reset Password", html);

            _logger.LogInformation("Forgot password email sent to: {Email}", email);

            return new BaseResponse<string> { Success = true, Message = "check your email please to reset the password" };
        }

        public async Task<BaseResponse<string>> ResetPasswordAsync(ResetPasswordDto dto)
        {
            _logger.LogInformation("Reset password attempt for email: {Email}", dto.Email);

            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                _logger.LogWarning("Reset password failed: user not found for email: {Email}", dto.Email);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "User not found",
                };
            }

            var result = await _userManager.ResetPasswordAsync(user, dto.Token, dto.NewPassword);
            if (!result.Succeeded)
            {
                _logger.LogWarning("Reset password failed for email: {Email}. Errors: {Errors}", dto.Email, string.Join(", ", result.Errors.Select(e => e.Description)));
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "Password reset failed.",
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }

            _logger.LogInformation("Password reset successfully for email: {Email}", dto.Email);

            return new BaseResponse<string>
            {
                Success = true,
                Message = "Password reset successfully."
            };
        }

        public async Task<BaseResponse<string>> SendConfirmationEmailAsync(string email)
        {
            _logger.LogInformation("Send confirmation email attempt for email: {Email}", email);

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogWarning("Send confirmation email failed: user not found for email: {Email}", email);
                return new BaseResponse<string> { Success = false, Message = "User not found" };
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = $"{BaseAddress.Remote}/api/v1/auth/confirmEmail?userId={user.Id}&token={Uri.EscapeDataString(token)}";

            var html = $"<p>Please confirm your email by clicking <a href='{confirmationLink}'>here</a>.</p>";
            await _emailService.SendEmailAsync(email, "Confirm your email", html);

            _logger.LogInformation("Confirmation email sent to: {Email}", email);

            return new BaseResponse<string> { Success = true, Message = "check your email please" };
        }

        private async Task<string> GenerateJwtToken(AppUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.GivenName, user.Name ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim("BelongToUserId", user.BelongToUserId.ToString() ?? ""),
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
                expires: DateTime.UtcNow.AddDays(_jwtOptions.Value.DurationInMinutes),
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

        public async Task<BaseResponse<AuthResponse>> RefreshAccessTokenByRefreshTokenAsync(string token)
        {
            _logger.LogInformation("Refresh access token attempt with refresh token");

            var response = new BaseResponse<AuthResponse>();

            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user == null)
            {
                _logger.LogWarning("Refresh access token failed: invalid token");
                response.Success = false;
                response.Message = "Invalid Token";
                return response;
            }

            var refreshToken = user.RefreshTokens.SingleOrDefault(t => t.Token == token);

            if (refreshToken == null || !refreshToken.IsActive)
            {
                _logger.LogWarning("Refresh access token failed: inactive or invalid token");
                response.Success = false;
                response.Message = "Inactive or invalid token";
                return response;
            }

            refreshToken.RevokedOn = DateTime.UtcNow;

            var newRefreshToken = GenerateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
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

            _logger.LogInformation("Access token refreshed successfully for user: {Email}", user.Email);

            return response;
        }

        public async Task<BaseResponse<string>> LogoutAsync(string refreshToken)
        {
            _logger.LogInformation("Logout attempt with refresh token");

            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
            if (user == null)
            {
                _logger.LogWarning("Logout failed: user not found for provided refresh token");
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "User not found for the provided refresh token."
                };
            }

            var token = user.RefreshTokens.SingleOrDefault(t => t.Token == refreshToken && t.IsActive);
            if (token == null)
            {
                _logger.LogWarning("Logout failed: no active refresh token found");
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "No active refresh token found."
                };
            }

            token.RevokedOn = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);

            _logger.LogInformation("Logout successful for user: {Email}", user.Email);

            return new BaseResponse<string>
            {
                Success = true,
                Message = "Logout successful."
            };
        }
    }
}
