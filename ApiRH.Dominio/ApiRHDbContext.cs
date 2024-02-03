using ApiRH.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiRH.Dominio;

public class ApiRHDbContext : DbContext
{
    public ApiRHDbContext(DbContextOptions options) : base(options)
    {        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Tecnologia> Tecnologia { get; set; } 
}
