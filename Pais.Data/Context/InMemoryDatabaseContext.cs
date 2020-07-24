using Pais.Domain.Entities;
using System.Collections.Generic;

namespace Pais.Data.Context
{
    /// <summary>
    /// 
    /// </summary>
    public class InMemoryDatabaseContext
    {
        /// <summary>
        /// 
        /// </summary>
        public ISet<Federacao> Customers { get; } = new HashSet<Federacao>();
    }
}
