using Federations.Data.Contexts;
using Federations.Domain.Models;
using Federations.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Federations.Data.Repositories
{
    public class FederationRepository : IFederationRepository
    {
        private readonly InMemoryDatabaseContext _context;

        public FederationRepository(InMemoryDatabaseContext context)
        {
            _context = context;
        }

        public Task Add(FederationModel federation)
        {
            _context.Federations.Add(federation);
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<FederationModel>> Find(Expression<Func<FederationModel, bool>> expression)
        {
            return await _context.Federations.Where(expression).ToListAsync();
        }

        public async Task<FederationModel> GetById(string id)
        {
            return await _context.Federations.FirstOrDefaultAsync(federation => federation.Id == id);
        }

        public Task Remove(FederationModel federation)
        {
            _context.Federations.Remove(federation);
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Task Update(FederationModel federation)
        {
            _context.Federations.Update(federation);
            _context.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
