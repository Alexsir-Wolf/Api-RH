using ApiRH.Dominio.Commands.Output.Candidatos;
using ApiRH.Dominio.Commands.Output.Tecnologias;
using ApiRH.Dominio.Commands.Output.Vagas;
using ApiRH.Dominio.Entidades;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApiRH.Dominio.Commands.Output.Vagas;

public class VagaCommandResult
{
    public VagaCommandResult()
    {
    }

    public VagaCommandResult(int? vagaId)
    {
        VagaId = vagaId;
    }

    public VagaCommandResult(
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

    public VagaCommandResult MontaVaga(Vaga? command)
    {
        var tec = new TecnologiaCommandResult().AdicionarVagaTecnologias(
            command.VagaTecnologias.ToList());    
        
        var candidatos = new CandidatoCommandResult().AdicionarVagaCandidatos(
            command.VagaCandidatos.ToList());

        return new VagaCommandResult(
            command.Id,
            command.Descricao,
            tec,
            candidatos,
            command.Ativo);
    }

    public List<VagaCommandResult> MontarLista(ICollection<Vaga> vagas)
    {
        var result = new List<VagaCommandResult>();

        foreach (var vaga in vagas)
        {
            var tec = new TecnologiaCommandResult().AdicionarVagaTecnologias(
                vaga.VagaTecnologias.ToList());

            var candidatos = new CandidatoCommandResult().AdicionarVagaCandidatos(
                vaga.VagaCandidatos.ToList());

            result.Add(new VagaCommandResult(
                vaga.Id,
                vaga.Descricao,
                tec,
                candidatos,
                vaga.Ativo));
        }
        return result;
    }


}
