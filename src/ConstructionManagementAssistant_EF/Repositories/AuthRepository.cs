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

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return null!;

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

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

    }
}

