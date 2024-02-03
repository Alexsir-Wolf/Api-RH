using ApiRH.Dominio.Entidades;

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

    public CandidatoDetalheCommandResult MontarCandidato(Candidato candidato)
    {
        return new CandidatoDetalheCommandResult(
            candidato.Id,
            candidato.Nome,
            candidato.Funcao,
            candidato.Ativo);
    }
}
