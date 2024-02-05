using ApiRH.Dominio.Commands.Output.Candidatos;
using ApiRH.Dominio.Commands.Output.Tecnologias;
using ApiRH.Dominio.Entidades;

namespace ApiRH.Dominio.Commands.Output.Vagas;

public class VagaDetalheCommandResult
{
    public VagaDetalheCommandResult()
    {
    }

    public VagaDetalheCommandResult(
        int? vagaId,
        string? descricao,
        ICollection<TecnologiaCommandResult> tecnologias,
        ICollection<CandidatoCommandResult> candidatos,
        bool ativo)
    {
        VagaId = vagaId;
        Descricao = descricao;
        Status = ativo ? "Ativo" : "Inativo";
    }

    public int? VagaId { get; private set; }
    public string? Descricao { get; private set; }
    public string? Status { get; private set; }

    public ICollection<TecnologiaCommandResult>? Tecnologias { get; set; }
    public ICollection<CandidatoCommandResult>? Candidatos { get; set; }

    public VagaDetalheCommandResult MontaVaga(Vaga? command)
    {
        var tec = new TecnologiaCommandResult().AdicionarVagaTecnologias(
            command.VagaTecnologias.ToList());

        var candidatos = new CandidatoCommandResult().AdicionarVagaCandidatos(
            command.VagaCandidatos.ToList());

        return new VagaDetalheCommandResult(
            command.Id,
            command.Descricao,
            tec,
            candidatos,
            command.Ativo);
    }
}
