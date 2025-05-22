using ConstructionManagementAssistant.Core.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;

namespace ConstructionManagementAssistant.API.Controllers
{

    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        /// <summary>
        /// Authenticates a user and returns an access token if successful.
        /// </summary>
        /// <param name="loginDto">The login credentials (email and password).</param>
        /// <returns>
        /// 200 OK with <see cref="AuthResponse"/> if login is successful.<br/>
        /// 401 Unauthorized with error details if login fails.
        /// </returns>
        [HttpPost(SystemApiRouts.Auth.Login)]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var response = await _authService.LoginAsync(loginDto);
            if (response.Success)
                return Ok(response);
            return Unauthorized(response);
        }

        /// <summary>
        /// Registers a new user in the system.
        /// </summary>
        /// <param name="registerDto">The registration data (name, email, password, phone number, etc.).</param>
        /// <remarks>
        /// <b>ClientType Enum Values:</b><br/>
        /// 1 - Admin (مدير)<br/>
        /// 2 - SiteEngineer (مهندس موقع)
        /// </remarks>
        /// <returns>
        /// 200 OK with <see cref="AuthResponse"/> if registration is successful.<br/>
        /// 401 Unauthorized with error details if registration fails.
        /// </returns>
        [HttpPost(SystemApiRouts.Auth.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var response = await _authService.RegisterAsync(registerDto);
            if (response.Success)
                return Ok(response);

            return Unauthorized(response);
        }

        /// <summary>
        /// Sends a confirmation email to the specified user email address.
        /// </summary>
        /// <param name="email">The user's email address.</param>
        /// <returns>
        /// 200 OK if the confirmation email was sent.<br/>
        /// 404 Not Found if the user does not exist.
        /// </returns>
        [HttpPost(SystemApiRouts.Auth.SendConfirmationEmail)]
        public async Task<IActionResult> SendConfirmationEmail([FromQuery] string email)
        {
            var send = await _authService.SendConfirmationEmailAsync(email);
            if (send.Success)
                return Ok("Confirmation email sent.");

            return NotFound("User not found");
        }

        /// <summary>
        /// Confirms a user's email address using a user ID and confirmation token.
        /// </summary>
        /// <param name="userId">The user's ID.</param>
        /// <param name="token">The email confirmation token.</param>
        /// <returns>
        /// Redirects to the frontend with the result of the confirmation.<br/>
        /// Query parameters: <c>success</c> (true/false), <c>email</c> (on success), <c>message</c> (on failure).
        /// </returns>
        [HttpGet(SystemApiRouts.Auth.confirmEmail)]
        public async Task<IActionResult> ConfirmEmail([FromQuery] int userId, [FromQuery] string token)
        {
            var result = await _authService.ConfirmEmailAsync(userId, token);
            if (result.Success)
            {
                // Redirect to frontend with success
                return Redirect($"https://yourfrontend.com/email-confirmed?success=true&email={result.Data.Email}");
            }
            else
            {
                // Redirect to frontend with error message
                return Redirect($"https://yourfrontend.com/email-confirmed?success=false&message={Uri.EscapeDataString(result.Message)}");
            }
        }

        /// <summary>
        /// Initiates the password reset process by sending a reset link to the user's email.
        /// </summary>
        /// <param name="email">The email address of the user requesting a password reset.</param>
        /// <returns>
        /// 200 OK if the reset email was sent.<br/>
        /// 400 Bad Request if the user does not exist or the request is invalid.
        /// </returns>
        [HttpPost(SystemApiRouts.Auth.ForgotPassword)]
        public async Task<IActionResult> ForgotPassword([FromQuery] string email)
        {
            var user = await _authService.ForgotPasswordAsync(email);
            if (user.Success)
            {
                return Ok(user);
            }
            return BadRequest(user);
        }

        /// <summary>
        /// Resets the user's password using the provided token and new password.
        /// </summary>
        /// <param name="email">The user's email address.</param>
        /// <param name="token">The password reset token sent to the user's email.</param>
        /// <param name="newPassowrd">The new password to set for the user.</param>
        /// <returns>
        /// Redirects to the frontend with the result of the password reset.<br/>
        /// Query parameters: <c>success</c> (true/false), <c>message</c> (on failure).
        /// </returns>
        [HttpGet(SystemApiRouts.Auth.ResetPassWord)]
        public async Task<IActionResult> ResetPassword(
            [FromQuery] string email,
            [FromQuery] string token,
            [FromQuery] string? newPassowrd = null)
        {
            var dto = new ResetPasswordDto { Email = email, Token = token, NewPassword = newPassowrd };
            var result = await _authService.ResetPasswordAsync(dto);

            if (result.Success)
            {
                // Redirect to frontend with success
                return Redirect($"https://yourfrontend.com/reset-password?success=true&");
            }
            else
            {
                // Redirect to frontend with error message
                return Redirect($"https://yourfrontend.com/reset-password?success=false&message={Uri.EscapeDataString(result.Message)}");
            }
        }

        /// <summary>
        /// Logs out the currently authenticated user and invalidates their refresh token.
        /// </summary>
        /// <returns>
        /// 200 OK if logout is successful.<br/>
        /// 401 Unauthorized if the user is not authenticated or logout fails.
        /// </returns>
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
