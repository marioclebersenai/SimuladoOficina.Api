using Microsoft.EntityFrameworkCore;
using SimuladoOficina.Api.Models;

namespace SimuladoOficina.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}