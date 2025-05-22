using ConstructionManagementAssistant.Core.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;

namespace ConstructionManagementAssistant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        /// <summary>
        /// عملية الدخول للنظام
        /// </summary>
        /// <param name="loginDto">بيانات الدخول (البريد وكلمة المرور)</param>
        /// <returns>رمز دخول (JWT) في حال النجاح أو رسالة خطأ</returns>
        [ProducesResponseType(typeof(BaseResponse<ResponseLogin>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<ResponseLogin>), StatusCodes.Status401Unauthorized)]
        [HttpPost(SystemApiRouts.Auth.Login)]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var response = await _authService.LoginAsync(loginDto);
            if (response.Success)
                return Ok(response);
            return Unauthorized(response);
        }

        /// <summary>
        /// عملية التسجيل بالنظام
        /// </summary>
        /// <param name="registerDto">بيانات المستخدم الجديد</param>
        /// <remarks>
        /// ClientType Enum Values:
        /// 1 - Admin (مدير)
        /// 2 - SiteEngineer (مهندس موقع)
        /// </remarks>
        /// <returns>رمز دخول جديد أو رسالة خطأ توضح سبب الفشل</returns>
        [ProducesResponseType(typeof(BaseResponse<ResponseLogin>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<ResponseLogin>), StatusCodes.Status401Unauthorized)]
        [HttpPost(SystemApiRouts.Auth.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var response = await _authService.RegisterAsync(registerDto);
            if (response.Success)
                return Ok(response);

            return Unauthorized(response);
        }

        /// <summary>
        /// إرسال رابط إعادة تعيين كلمة المرور إلى البريد الإلكتروني
        /// </summary>
        /// <param name="dto">البريد الإلكتروني للمستخدم</param>
        /// <returns>نجاح العملية أو رسالة خطأ</returns>
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
        [HttpPost(SystemApiRouts.Auth.ForgotPassword)]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            var user = await _authService.ForgotPasswordAsync(dto);
            if (user.Success)
            {
                return Ok(user);
            }
            return BadRequest(user);
        }
        /// <summary>
        /// إعادة تعيين كلمة المرور باستخدام رمز الاستعادة (Reset Token)
        /// </summary>
        /// <param name="dto">بيانات إعادة التعيين: البريد، الرمز، وكلمة المرور الجديدة</param>
        /// <returns>نجاح العملية أو رسالة خطأ</returns>
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
        [HttpPost(SystemApiRouts.Auth.ResetPassWord)]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var user = await _authService.ResetPasswordAsync(dto);
            if (user.Success)
            {
                return Ok(user);
            }
            return BadRequest(user);

        }
        /// <summary>
        /// إرسال رابط تأكيد البريد الإلكتروني للمستخدم
        /// </summary>
        /// <param name="email">البريد الإلكتروني للمستخدم</param>
        /// <returns>رسالة نجاح أو خطأ في حال عدم وجود المستخدم</returns>
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
        [HttpPost(SystemApiRouts.Auth.SendConfirmationEmail)]
        public async Task<IActionResult> SendConfirmationEmail([FromQuery] string email)
        {
            var send = await _authService.SendConfirmationEmailAsync(email);
            if (send.Success)
                return Ok(send);

            return NotFound(send);
        }

        /// <summary>
        /// تأكيد البريد الإلكتروني باستخدام التوكن
        /// </summary>
        /// <param name="dto">بيانات التأكيد: UserId وToken</param>
        /// <returns>نجاح التفعيل أو رسالة توضح أن المستخدم غير موجود أو الرمز خاطئ</returns>
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
        [HttpPost(SystemApiRouts.Auth.confirmEmail)]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailDto dto)
        {
            if (dto.UserId == null || dto.Token == null)
                return BadRequest(new BaseResponse<string>
                {
                    Success = false,
                    Message = "Invalid confirmation data"
                });

            var confirmed = await _authService.ConfirmEmailAsync(dto);
            if (confirmed.Success)
                return Ok(confirmed);


            return NotFound(confirmed);




        }
        /// <summary>
        /// تسجيل الخروج من النظام وإلغاء صلاحية الـ Refresh Token
        /// </summary>
        /// <returns>رسالة نجاح في حال تم الخروج أو رسالة خطأ في حال عدم المصادقة</returns>
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var response = await _authService.LogoutAsync(User);
            if (!response.Success)
                return Unauthorized(response);

            return Ok(response);
        }
    }
}
