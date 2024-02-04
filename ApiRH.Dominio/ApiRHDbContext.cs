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

        //Relacionamento EmpresaTecnologia
        modelBuilder.Entity<EmpresaTecnologia>()
            .HasKey(et => new { et.EmpresaId, et.TecnologiaId });

        modelBuilder.Entity<EmpresaTecnologia>()
            .HasOne(et => et.Empresa)
            .WithMany(e => e.EmpresaTecnologias)
            .HasForeignKey(et => et.EmpresaId);

        modelBuilder.Entity<EmpresaTecnologia>()
            .HasOne(et => et.Tecnologia)
            .WithMany(t => t.EmpresaTecnologias)
            .HasForeignKey(et => et.TecnologiaId);

        //Relacionamento CandidatoTecnologia
        modelBuilder.Entity<CandidatoTecnologia>()
            .HasKey(ct => new { ct.CandidatoId, ct.TecnologiaId });

        modelBuilder.Entity<CandidatoTecnologia>()
            .HasOne(ct => ct.Candidato)
            .WithMany(e => e.CandidatoTecnologias)
            .HasForeignKey(ct => ct.CandidatoId);

        modelBuilder.Entity<CandidatoTecnologia>()
            .HasOne(ct => ct.Tecnologia)
            .WithMany(t => t.CandidatoTecnologias)
            .HasForeignKey(ct => ct.TecnologiaId);
    }

    public DbSet<Candidato> Candidato { get; set; } 
    public DbSet<CandidatoTecnologia> CandidatoTecnologia { get; set; }
    public DbSet<EmpresaTecnologia> EmpresaTecnologia { get; set; }
    public DbSet<Empresa> Empresa { get; set; }
    public DbSet<Tecnologia> Tecnologia { get; set; }
}
