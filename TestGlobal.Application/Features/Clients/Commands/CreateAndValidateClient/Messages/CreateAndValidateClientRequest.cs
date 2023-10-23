using MediatR;
using TestGlobal.Domail.Common;

namespace TestGlobal.Application.Features.Clients.Commands.CreateAndValidateClient.Message
{
    public class CreateAndValidateClientRequest : IRequest<CreateAndValidateClientResponse>
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Cpf { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
    }
}
