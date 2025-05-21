using ConstructionManagementAssistant.Core.DTOs.Auth;
using ConstructionManagementAssistant.Core.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ConstructionManagementAssistant.EF.Repositories
{
    public class AuthRepository : IAuthService
    {
        private readonly UserManager<ApplicationIdentity> _userManager;
        private readonly IOptions<JWTSettings> _jwtOptions;

        public AuthRepository(UserManager<ApplicationIdentity> userManager, IOptions<JWTSettings> jwtOptions)
        {
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

            return new BaseResponse<ResponseLogin>
            {
                Data = new ResponseLogin
                {
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    Email = user.Email,
                    Token = await GenerateJwtToken(user)

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
                EmailConfirmed = true,
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
                    Token = await GenerateJwtToken(user)

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
                return new BaseResponse<string>
                {
                    Success = true,
                    Message = "No Email Found"
                };

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return new BaseResponse<string>
            {
                Success = true,
                Message = "Reset token generated successfully.",
                Data = token
            };
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

        private async Task<string> GenerateJwtToken(ApplicationIdentity user)
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
                expires: DateTime.UtcNow.AddDays(_jwtOptions.Value.DurationInDays),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}




