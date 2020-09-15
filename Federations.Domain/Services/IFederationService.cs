using Federations.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Federations.Domain.Services
{
    public interface IFederationService
    {
        Task<FederationModel> Add(CreateFederation command);
        Task<FederationModel> Update(UpdateFederation command);
        Task Remove(string id);
        Task<FederationModel> GetById(string id);
        Task<IEnumerable<FederationModel>> Find();
    }
}
