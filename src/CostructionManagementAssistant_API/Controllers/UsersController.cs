using ConstructionManagementAssistant.Core.Extentions;
using ConstructionManagementAssistant.Core.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ConstructionManagementAssistant.API.Controllers;

[ApiController]
[Authorize]
public class UsersController(UserManager<AppUser> userManager) : ControllerBase
{


    [HttpGet(SystemApiRouts.Users.GetProfile)]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserById()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        var profile = await userManager.FindByIdAsync(userId);
        if (profile == null)
            return NotFound();

        var userDto = profile.ToUserDto();
        return Ok(userDto);
    }

}
