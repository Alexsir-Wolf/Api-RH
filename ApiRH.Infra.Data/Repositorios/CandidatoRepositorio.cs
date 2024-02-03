using ApiRH.Dominio;
using ApiRH.Dominio.Contratos.Repositorios;
using ApiRH.Dominio.Entidades;
using ApiRH.Infra.Data.Repositorios.Base;

namespace ApiRH.Infra.Data.Repositorios;

public class CandidatoRepositorio : BaseRepositorio<Candidato, int>, ICandidatoRepositorio 
{
    private readonly ApiRHDbContext _dbContext;

    public CandidatoRepositorio(ApiRHDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}