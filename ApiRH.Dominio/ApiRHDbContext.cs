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

        modelBuilder.Entity<EmpresaTecnologia>()
            .HasKey(et => new { et.EmpresaId, et.TecnologiaId });

        modelBuilder.Entity<EmpresaTecnologia>()
            .HasOne(et => et.Empresa)
            .WithMany(e => e.EmpresasTecnologias)
            .HasForeignKey(et => et.EmpresaId);

        modelBuilder.Entity<EmpresaTecnologia>()
            .HasOne(et => et.Tecnologia)
            .WithMany(t => t.EmpresasTecnologias)
            .HasForeignKey(et => et.TecnologiaId);
    }

    public DbSet<Candidato> Candidato { get; set; } 
    public DbSet<EmpresaTecnologia> EmpresaTecnologia { get; set; }
    public DbSet<Empresa> Empresa { get; set; }
    public DbSet<Tecnologia> Tecnologia { get; set; }
}
