using MediatR;

namespace TestGlobal.Application.Features.Clients.Commands.DeleteClient.Messages
{
    public class DeleteClientRequest : IRequest<DeleteClientResponse>
    {
        public string Cpf { get; set; }
    }
}
