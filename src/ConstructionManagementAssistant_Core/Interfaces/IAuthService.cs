namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDto loginDto);
    }
}
