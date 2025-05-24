namespace ConstructionManagementAssistant.Core.Extentions;

public static class UserDtoExtensions
{
    public static UserDto ToUserDto(this AppUser user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));
        return new UserDto
        {
            Name = user.Name,
            UserName = user.UserName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber
        };
    }
}
