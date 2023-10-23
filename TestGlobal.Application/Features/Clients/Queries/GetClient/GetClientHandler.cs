using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TestGlobal.Application.Contracts.Persistence;
using TestGlobal.Application.Features.Clients.Commands.CreateAndValidateClient;
using TestGlobal.Application.Features.Clients.Queries.GetClient.Messages;

namespace TestGlobal.Application.Features.Clients.Queries.GetClient
{
    public class GetClientHandler : IRequestHandler<GetClientRequest, GetClientResponse>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAndValidateClientHandler> _logger;

        public GetClientHandler(IClientRepository clientRepository, IMapper mapper, ILogger<CreateAndValidateClientHandler> logger)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetClientResponse> Handle(GetClientRequest request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetClientByDocument(request.Cpf);

            if (client != null)
            {
                return new GetClientResponse { Success = true, ClientData = _mapper.Map<ClientData>(client) };
            }

            _logger.LogInformation($"Client not found with cpf {request.Cpf}");

            return new GetClientResponse { Success = false };
        }
    }
}
