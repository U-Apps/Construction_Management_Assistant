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
        [HttpPost("loginUser")]
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
        [HttpPost("registerUser")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var response = await _authService.RegisterAsync(registerDto);
            if (response.Success)
                return Ok(response);

            return Unauthorized(response);
        }

        [HttpPost("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            throw new NotImplementedException();
        }

        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            var user = await _authService.ForgotPasswordAsync(dto);
            if (user.Success)
            {
                return Ok(user);
            }
            return BadRequest(user);
        }
        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var user = await _authService.ResetPasswordAsync(dto);
            if (user.Success)
            {
                return Ok(user);
            }
            return BadRequest(user);

        }




    }
}
