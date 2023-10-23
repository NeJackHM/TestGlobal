using AutoMapper;
using TestGlobal.Application.Features.Clients.Commands.CreateAndValidateClient.Message;
using TestGlobal.Application.Features.Clients.Commands.UpdateClient.Messages;
using TestGlobal.Application.Features.Clients.Queries.GetClient.Messages;
using TestGlobal.Domail.Models;

namespace TestGlobal.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<ORIGIN,DESTINATION>();
            CreateMap<CreateAndValidateClientRequest, Client>();
            CreateMap<Client, ClientData>();
            CreateMap<UpdateClientRequest, Client>();
        }
    }
}
