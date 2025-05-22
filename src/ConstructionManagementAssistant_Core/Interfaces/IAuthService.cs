using ConstructionManagementAssistant.Core.DTOs.Auth;
using ConstructionManagementAssistant.Core.Models.Response;
using System.Security.Claims;

namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface IAuthService
    {
        Task<BaseResponse<AuthResponse>> LoginAsync(LoginDto loginDto);
        Task<BaseResponse<AuthResponse>> RegisterAsync(RegisterDto registerDto);

        Task<BaseResponse<string>> ForgotPasswordAsync(ForgotPasswordDto dto);

        Task<BaseResponse<string>> ResetPasswordAsync(ResetPasswordDto dto);


        Task<BaseResponse<AuthResponse>> RefreshTokenAsync(string token);

        Task<BaseResponse<string>> LogoutAsync(ClaimsPrincipal userPrincipal);


        Task<BaseResponse<string>> SendConfirmationEmailAsync(string email);

        Task<BaseResponse<string>> ConfirmEmailAsync(ConfirmEmailDto dto);


    }
}
