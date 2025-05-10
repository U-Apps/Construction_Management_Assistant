using ConstructionManagementAssistant.Core.Models.Response;

namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        public Task<ClientDetailsDto> GetClientById(int id);
        public Task<PagedResult<GetClientDto>> GetAllClients(
            int pageNumber,
            int pageSize,
            string? searchTerm = null,
            ClientType? clientType = null);
        public Task<BaseResponse<string>> AddClientAsync(AddClientDto clientDto);
        public Task<BaseResponse<string>> UpdateClientAsync(UpdateClientDto clientDto);
        public Task<BaseResponse<string>> DeleteClientAsync(int id);
    }
}
