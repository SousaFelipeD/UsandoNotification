using Pais.Application.Models;
using Pais.Domain.Entities;
using Pais.Domain.Interfaces.Repositories;
using Pais.Domain.Notification;
using System.Threading;
using System.Threading.Tasks;

namespace Pais.Application.Services
{
    public class FederacaoService
    {
        private readonly NotificationContext notificationContext;
        private readonly IFederacaoRepository federacaoRepository;

        public FederacaoService(NotificationContext notificationContext, IFederacaoRepository federacaoRepository)
        {
            this.notificationContext = notificationContext;
            this.federacaoRepository = federacaoRepository;
        }

        public async Task<uint> Handle(FederacaoCreate request, CancellationToken cancellationToken)
        {
            var pais = new Federacao(request.Nome) 
            {
                Ddi = request.Ddi,
                Numero = request.Numero,
                Sigla = request.Sigla,
                Id = 1,
            };

            if (!pais.Valid)
            {
                notificationContext.AddNotifications(pais.ValidationResult);
                return 0;
            }

            await federacaoRepository.Save(pais);

            return pais.Id;
        }
    }
}
