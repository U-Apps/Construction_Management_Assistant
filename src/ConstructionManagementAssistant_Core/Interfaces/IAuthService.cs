using ConstructionManagementAssistant.Core.DTOs.Auth;
using ConstructionManagementAssistant.Core.Models.Response;
using System.Security.Claims;

namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface IAuthService
    {
        Task<BaseResponse<ResponseLogin>> LoginAsync(LoginDto loginDto);
        Task<BaseResponse<ResponseLogin>> RegisterAsync(RegisterDto registerDto);

        Task<BaseResponse<string>> ForgotPasswordAsync(ForgotPasswordDto dto);

        Task<BaseResponse<string>> ResetPasswordAsync(ResetPasswordDto dto);

        Task<BaseResponse<string>> SendConfirmationEmailAsync(string email);

        Task<BaseResponse<string>> ConfirmEmailAsync(ConfirmEmailDto dto);

        Task<BaseResponse<TokenDto>> RefreshTokenAsync(TokenDto dto);

        Task<BaseResponse<string>> LogoutAsync(ClaimsPrincipal userPrincipal);

    }
}
