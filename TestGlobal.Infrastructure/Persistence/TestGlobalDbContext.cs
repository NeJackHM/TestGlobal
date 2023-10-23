using Microsoft.EntityFrameworkCore;
using TestGlobal.Domail.Common;
using TestGlobal.Domail.Models;
using TestGlobal.Infrastructure.Mappings;

namespace TestGlobal.Infrastructure.Persistence
{
    public class TestGlobalDbContext : DbContext
    {
        public TestGlobalDbContext(DbContextOptions<TestGlobalDbContext> options) : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-EL92NMVT;Initial Catalog=TestGlobal;user id=sa;password=password123")
        //        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
        //        .EnableSensitiveDataLogging();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientsMap());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        //entry.Entity.CreatedAt = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
