using AgendaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ContatoModel> Contatos { get; set; }  
    }
}