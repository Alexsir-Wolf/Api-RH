using ApiRH.Dominio.Commands.Output.Tecnologias;
using ApiRH.Dominio.Entidades;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApiRH.Dominio.Commands.Output.Candidatos;

public class CandidatoCommandResult
{
    public CandidatoCommandResult()
    {
    }
    public CandidatoCommandResult(
        int? id,
        string? nome,
        string? funcao,
        ICollection<TecnologiaCommandResult>? tecnologias,
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

    public ICollection<TecnologiaCommandResult>? Tecnologias { get; set; }

    public CandidatoCommandResult MontaCandidato(Candidato? command)
    {
        var tec = new TecnologiaCommandResult().AdicionarCandidatoTecnologias(
            command.CandidatoTecnologias.ToList());

        return new CandidatoCommandResult(
            command.Id,
            command.Nome,
            command.Funcao,
            tec,
            command.Ativo);
    }

    public List<CandidatoCommandResult> MontarLista(ICollection<Candidato> candidatos)
    {
        var result = new List<CandidatoCommandResult>();

        foreach (var candidato in candidatos)
        {
            var tec = new TecnologiaCommandResult().AdicionarCandidatoTecnologias(
                    candidato.CandidatoTecnologias.ToList());

            result.Add(new CandidatoCommandResult(
                candidato.Id,
                candidato.Nome,
                candidato.Funcao,
                tec,
                candidato.Ativo));
        }
        return result;
    }
}
