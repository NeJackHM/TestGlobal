using TestGlobal.Domail.Common;

namespace TestGlobal.Domail.Models
{
    public class Client : BaseDomainModel
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string Cpf { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
    }
}
