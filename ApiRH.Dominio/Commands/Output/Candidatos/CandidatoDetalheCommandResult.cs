using ApiRH.Dominio.Commands.Output.Tecnologias;
using ApiRH.Dominio.Entidades;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApiRH.Dominio.Commands.Output.Candidatos;

public class CandidatoDetalheCommandResult
{
    public CandidatoDetalheCommandResult()
    {
    }

    public CandidatoDetalheCommandResult(
        int? id,
        string? nome,
        string? funcao,
        ICollection<TecnologiaDetalheCommandResult> tecnologias,
        bool ativo)
    {
        Id = id;
        Nome = nome;
        Funcao = funcao;
        Tecnologias = tecnologias;
        Status = ativo ? "Ativo" : "Inativo";
    }

    public int? Id { get; private set; }
    public string? Nome { get; private set; }
    public string? Funcao { get; private set; }
    public string? Status { get; private set; }

    public ICollection<TecnologiaDetalheCommandResult>? Tecnologias { get; set; }

    public CandidatoDetalheCommandResult MontarCandidato(Candidato candidato)
    {
        var tec = new TecnologiaDetalheCommandResult().AdicionarCandidatoTecnologias(
           candidato.CandidatoTecnologias.ToList());

        return new CandidatoDetalheCommandResult(
            candidato.Id,
            candidato.Nome,
            candidato.Funcao,
            tec,
            candidato.Ativo);
    }
}
