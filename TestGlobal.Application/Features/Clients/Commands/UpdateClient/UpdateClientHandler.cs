using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;
using TestGlobal.Application.Contracts.Persistence;
using TestGlobal.Application.Features.Clients.Commands.CreateAndValidateClient;
using TestGlobal.Application.Features.Clients.Commands.UpdateClient.Messages;
using TestGlobal.Domail.Models;

namespace TestGlobal.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientHandler : IRequestHandler<UpdateClientRequest, UpdateClientResponse>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAndValidateClientHandler> _logger;

        public UpdateClientHandler(IClientRepository clientRepository, IMapper mapper, ILogger<CreateAndValidateClientHandler> logger)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UpdateClientResponse> Handle(UpdateClientRequest request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetClientByDocument(request.Cpf);

            if (client != null)
            {
                //var mapClient = _mapper.Map<Client>(request);}

                _mapper.Map(request, client, typeof(UpdateClientRequest), typeof(Client));

                var updatedClient = await _clientRepository.UpdateAsync(client);

                if (updatedClient != null)
                {
                    _logger.LogInformation($"Client was updated with id {updatedClient.Id}");
                    return new UpdateClientResponse { Success = true };
                }
            }

            return new UpdateClientResponse { Success = false };
        }
    }
}
