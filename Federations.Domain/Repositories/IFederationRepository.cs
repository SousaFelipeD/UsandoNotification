using Federations.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Federations.Domain.Repositories
{
    public interface IFederationRepository
    {
        Task Add(FederationModel federation);
        Task Update(FederationModel federation);
        Task Remove(FederationModel federation);
        Task<FederationModel> GetById(string id);
        Task<IEnumerable<FederationModel>> Find(Expression<Func<FederationModel, bool>> expression);
    }
}
