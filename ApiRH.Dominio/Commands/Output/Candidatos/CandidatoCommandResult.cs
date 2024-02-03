using ApiRH.Dominio.Entidades;

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
        bool ativo)
    {
        Id = id;
        Nome = nome;
        Funcao = funcao;
        Status = ativo ? "Ativo" : "Inativo";
    }

    public int? Id { get; private set; }
    public string? Nome { get; private set; }
    public string? Funcao { get; private set; }
    public string? Status { get; private set; }

    public CandidatoCommandResult MontaCandidato(Candidato? command)
    {
        return new CandidatoCommandResult(
            command.Id,
            command.Nome,
            command.Funcao,
            command.Ativo);
    }

    public List<CandidatoCommandResult> MontarLista(IQueryable<Candidato> candidatos)
    {
        var result = new List<CandidatoCommandResult>();

        foreach (var candidato in candidatos)
        {
            result.Add(new CandidatoCommandResult(
                candidato.Id,
                candidato.Nome,
                candidato.Funcao,
                candidato.Ativo));
        }
        return result;
    }
}
