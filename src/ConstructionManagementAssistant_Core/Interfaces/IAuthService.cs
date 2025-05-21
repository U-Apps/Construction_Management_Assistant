using ConstructionManagementAssistant.Core.DTOs.Auth;
using ConstructionManagementAssistant.Core.Models.Response;

namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface IAuthService
    {
        Task<BaseResponse<ResponseLogin>> LoginAsync(LoginDto loginDto);
        Task<BaseResponse<ResponseLogin>> RegisterAsync(RegisterDto registerDto);

        Task<BaseResponse<string>> ForgotPasswordAsync(ForgotPasswordDto dto);

        Task<BaseResponse<string>> ResetPasswordAsync(ResetPasswordDto dto);
    }
}
