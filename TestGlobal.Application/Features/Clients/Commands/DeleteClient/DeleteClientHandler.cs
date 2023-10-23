using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TestGlobal.Application.Contracts.Persistence;
using TestGlobal.Application.Features.Clients.Commands.CreateAndValidateClient;
using TestGlobal.Application.Features.Clients.Commands.DeleteClient.Messages;

namespace TestGlobal.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientHandler : IRequestHandler<DeleteClientRequest, DeleteClientResponse>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAndValidateClientHandler> _logger;

        public DeleteClientHandler(IClientRepository clientRepository, IMapper mapper, ILogger<CreateAndValidateClientHandler> logger)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<DeleteClientResponse> Handle(DeleteClientRequest request, CancellationToken cancellationToken)
        {
            var clientDelete = await _clientRepository.GetClientByDocument(request.Cpf);

            if (clientDelete != null) 
            {
                clientDelete.Active = false;
                await _clientRepository.UpdateAsync(clientDelete);
                _logger.LogInformation($"Client was deleted with cpf {request.Cpf}");

                return new DeleteClientResponse { Success = true };
            }

            return new DeleteClientResponse { Success = false };
        }
    }
}
