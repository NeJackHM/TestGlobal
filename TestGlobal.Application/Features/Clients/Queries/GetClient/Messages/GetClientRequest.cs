using MediatR;

namespace TestGlobal.Application.Features.Clients.Queries.GetClient.Messages
{
    public class GetClientRequest :IRequest<GetClientResponse>
    {
        public string Cpf { get; set; }
    }
}
