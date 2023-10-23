using TestGlobal.Domail.Models;

namespace TestGlobal.Application.Contracts.Persistence
{
    public interface IClientRepository : IAsyncRepository<Client>
    {
        Task<Client> GetClientByDocument(string cpf);
    }
}
