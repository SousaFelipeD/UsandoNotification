using Federations.Application.Notifications;
using Federations.Domain.Entities;
using Federations.Domain.Models;
using Federations.Domain.Repositories;
using Federations.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Federations.Application.Services
{
    public class FederationService : IFederationService
    {
        private readonly IFederationRepository _federationRepository;
        private readonly NotificationContext _notificationContext;

        public FederationService(IFederationRepository federationRepository,
            NotificationContext notificationContext)
        {
            _federationRepository = federationRepository;
            _notificationContext = notificationContext;
        }

        public async Task<FederationModel> Add(CreateFederation command)
        {
            command.Validate();

            if (command.Invalid)
            {
                _notificationContext.AddNotifications(command);
                return null;
            }


            var federation = new Federation(command.Name);

            if (federation.Invalid)
            {
                _notificationContext.AddNotifications(federation);
                return null;
            }

            var model = new FederationModel
            {
                Id = federation.Id.ToString(),
                Name = federation.Name,
            };

            await _federationRepository.Add(model);

            return model;

        }

        public async Task<IEnumerable<FederationModel>> Find()
        {
            Expression<Func<FederationModel, bool>> exp = federation => !string.IsNullOrEmpty(federation.Id);

            return await _federationRepository.Find(exp);

        }

        public async Task<FederationModel> GetById(string id)
        {
            return await _federationRepository.GetById(id);
        }

        public async Task Remove(string id)
        {
            var federation = await _federationRepository.GetById(id);

            if (federation == null)
            {
                return;
            }

            await _federationRepository.Remove(federation);
        }

        public Task<FederationModel> Update(UpdateFederation command)
        {
            throw new NotImplementedException();
        }
    }
}
