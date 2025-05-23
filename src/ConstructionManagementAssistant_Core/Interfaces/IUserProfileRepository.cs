namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<UserProfileDto?> GetCurrentUserProfileAsync(int userId);
    }
}
