using ConstructionManagementAssistant.Core.DTOs.Auth;
using ConstructionManagementAssistant.Core.Models.Response;

namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface IAuthService
    {
        Task<BaseResponse<AuthResponse>> LoginAsync(LoginDto loginDto);
        Task<BaseResponse<string>> RegisterAsync(RegisterDto registerDto);

        Task<BaseResponse<string>> ForgotPasswordAsync(string email);

        Task<BaseResponse<string>> ResetPasswordAsync(ResetPasswordDto dto);


        Task<BaseResponse<AuthResponse>> RefreshAccessTokenByRefreshTokenAsync(string token);

        Task<BaseResponse<string>> LogoutAsync(string refreshToken);


        Task<BaseResponse<string>> SendConfirmationEmailAsync(string email);

        Task<BaseResponse<AuthResponse>> ConfirmEmailAsync(int userId, string token);


    }
}
