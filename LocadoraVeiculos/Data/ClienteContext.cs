using LocadoraVeiculos.Models;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculos.Data
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Mapeamento com banco de dados
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }

        public DbSet<Cliente> Clientes {get; set;}
        public DbSet<Veiculo> Veiculos { get; set;}
        public DbSet<Reserva> Reservas { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder) //Relacionamentos
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Cliente)
                .WithMany()
                .HasForeignKey(r => r.ClienteId);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Veiculo)
                .WithMany()
                .HasForeignKey(r => r.VeiculoId);
        }

    }
}
