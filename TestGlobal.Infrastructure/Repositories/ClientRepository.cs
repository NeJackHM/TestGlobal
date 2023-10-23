using Microsoft.EntityFrameworkCore;
using TestGlobal.Application.Contracts.Persistence;
using TestGlobal.Domail.Models;
using TestGlobal.Infrastructure.Persistence;

namespace TestGlobal.Infrastructure.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(TestGlobalDbContext context) : base(context)
        {
        }

        public async Task<Client> GetClientByDocument(string cpf)
        {
            return await _context.Clients!.Where(x => x.Cpf == cpf).FirstOrDefaultAsync();
        }
    }
}
