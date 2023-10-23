using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TestGlobal.Application.Contracts.Persistence;
using TestGlobal.Application.Features.Clients.Commands.CreateAndValidateClient.Message;
using TestGlobal.Domail.Models;

namespace TestGlobal.Application.Features.Clients.Commands.CreateAndValidateClient
{
    public class CreateAndValidateClientHandler : IRequestHandler<CreateAndValidateClientRequest, CreateAndValidateClientResponse>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAndValidateClientHandler> _logger;

        public CreateAndValidateClientHandler(IClientRepository clientRepository, IMapper mapper, ILogger<CreateAndValidateClientHandler> logger)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CreateAndValidateClientResponse> Handle(CreateAndValidateClientRequest request, CancellationToken cancellationToken)
        {
            var orderValidator = new CreateAndValidateClientValidator();
            var validationResult = orderValidator.Validate(request);

            if (!validationResult.IsValid)
                return new CreateAndValidateClientResponse { Success = false };

            var client = await _clientRepository.GetClientByDocument(request.Cpf);

            if (client == null)
            {
                var newClient = await _clientRepository.AddAsync(_mapper.Map<Client>(request));

                if (newClient != null)
                {
                    _logger.LogInformation($"New client was created with id {newClient.Id}");
                    return new CreateAndValidateClientResponse { Success = true };
                }
            }

            return new CreateAndValidateClientResponse { Success = false };
        }
    }
}
