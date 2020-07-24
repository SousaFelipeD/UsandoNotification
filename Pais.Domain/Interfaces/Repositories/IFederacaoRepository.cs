using Pais.Domain.Entities;
using System.Threading.Tasks;

namespace Pais.Domain.Interfaces.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFederacaoRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pais"></param>
        /// <returns></returns>
        Task Save(Federacao pais);
    }
}
