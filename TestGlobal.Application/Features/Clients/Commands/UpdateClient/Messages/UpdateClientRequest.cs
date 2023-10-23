using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGlobal.Application.Features.Clients.Commands.UpdateClient.Messages
{
    public class UpdateClientRequest : IRequest<UpdateClientResponse>
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Cpf { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
    }
}
