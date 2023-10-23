using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using TestGlobal.Domail.Models;

namespace TestGlobal.Infrastructure.Mappings
{
    public class ClientsMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> entity)
        {
            entity.Property(e => e.Id).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
            entity.Property(e => e.Address);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Active);
            entity.Property(e => e.Birthdate).IsRequired();
            entity.Property(e => e.Cpf).HasMaxLength(11).IsRequired();
        }
    }
}
