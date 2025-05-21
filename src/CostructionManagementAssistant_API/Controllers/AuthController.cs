using ConstructionManagementAssistant.Core.DTOs.Auth;

namespace ConstructionManagementAssistant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// عملية الدخول للنظام
        /// </summary>
        /// <param name="loginDto">بيانات الدخول</param>
        [HttpPost("login-User")]
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
        /// <param name="registerDto">بيانات التسجيل</param>
        /// <remarks>
        /// ClientType Enum Values:
        /// 1-Admin (مدير)
        /// 2- siteEngineer (مهندس موقع)
        /// </remarks>
        [HttpPost("register-User")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var response = await _authService.RegisterAsync(registerDto);
            if (response.Success)
                return Ok(response);

            return Unauthorized(response);
        }


        [HttpPost("Forgot-Password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            var user = await _authService.ForgotPasswordAsync(dto);
            if (user.Success)
            {
                return Ok(user);
            }
            return BadRequest(user);
        }
        [HttpPost("Reset-Password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var user = await _authService.ResetPasswordAsync(dto);
            if (user.Success)
            {
                return Ok(user);
            }
            return BadRequest(user);

        }
        [HttpPost("Send-Confirmation-Email")]
        public async Task<IActionResult> SendConfirmationEmail([FromQuery] string email)
        {
            var send = await _authService.SendConfirmationEmail(email);
            if (send.Success)
                return Ok("Confirmation email sent.");

            return NotFound("User not found");
        }
        [HttpPost("Confirm-Email")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailDto dto)
        {
            if (dto.UserId == null || dto.Token == null)
                return BadRequest(new BaseResponse<string>
                {
                    Success = false,
                    Message = "Invalid confirmation data"
                });

            var confirmed = await _authService.ConfirmEmail(dto);
            if (confirmed.Success)
                return Ok(confirmed);


            return NotFound(new BaseResponse<string>
            {
                Success = false,
                Message = "User not found"
            });




        }
    }
}
