namespace TestGlobal.Application.Features.Clients.Queries.GetClient.Messages
{
    public class GetClientResponse
    {
        public bool Success { get; set; }
        public ClientData ClientData { get; set; }
    }

    public class ClientData
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Cpf { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
    }
}
