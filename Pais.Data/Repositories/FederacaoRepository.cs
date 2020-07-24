using Pais.Data.Context;
using Pais.Domain.Entities;
using Pais.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Pais.Data.Repositories
{
    public class FederacaoRepository : IFederacaoRepository
    {
        private readonly InMemoryDatabaseContext _databaseContext;

        public FederacaoRepository(InMemoryDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Task Save(Federacao pais)
        {
            _databaseContext.Customers.Add(pais);
            return Task.CompletedTask;
        }
    }
}
