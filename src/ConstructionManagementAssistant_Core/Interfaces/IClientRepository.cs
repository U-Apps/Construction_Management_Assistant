using ConstructionManagementAssistant.Core.Models.Response;

namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        public Task<ClientDetailsDto?> GetClientById(int id);
        public Task<PagedResult<GetClientDto>> GetAllClients(
            string UserId,
            int pageNumber,
            int pageSize,
            string? searchTerm = null,
            ClientType? clientType = null);

        public Task<List<ClientNameDto>> GetClientsNames(string UserId);
        public Task<BaseResponse<string>> AddClientAsync(string UserId, AddClientDto clientDto);
        public Task<BaseResponse<string>> UpdateClientAsync(UpdateClientDto clientDto);
        public Task<BaseResponse<string>> DeleteClientAsync(int id);
    }
}
