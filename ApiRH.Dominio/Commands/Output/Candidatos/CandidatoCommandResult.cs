using ApiRH.Dominio.Commands.Output.Tecnologias;
using ApiRH.Dominio.Entidades;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApiRH.Dominio.Commands.Output.Candidatos;

public class CandidatoCommandResult
{
    public CandidatoCommandResult()
    {
    }
    public CandidatoCommandResult(int? candidatoId)
    {
        CandidatoId = candidatoId;
    }

    public CandidatoCommandResult(
        int? candidatoId,
        string? nome,
        string? funcao,
        ICollection<TecnologiaCommandResult>? tecnologias,
        bool ativo)
    {
        CandidatoId = candidatoId;
        Nome = nome;
        Funcao = funcao;
        Tecnologias = tecnologias;
        Status = ativo ? "Ativo" : "Inativo";
    }

    public int? CandidatoId { get; private set; }
    public string? Nome { get; private set; }
    public string? Funcao { get; private set; }
    public string? Status { get; private set; }

    public ICollection<TecnologiaCommandResult>? Tecnologias { get; set; }

    public CandidatoCommandResult MontaCandidato(Candidato? command)
    {
        var tecnologias = new List<TecnologiaCommandResult>();

        if (command.CandidatoTecnologias != null)
            foreach (var tec in command.CandidatoTecnologias)
                if (tec.Tecnologia != null) 
                    tecnologias.Add(new TecnologiaCommandResult().MontaTecnologia(tec.Tecnologia));
                else
                    tecnologias.Add(new TecnologiaCommandResult(tec.TecnologiaId));

        return new CandidatoCommandResult(
            command.Id,
            command.Nome,
            command.Funcao,
            tecnologias,
            command.Ativo);
    }

    public List<CandidatoCommandResult> MontarLista(ICollection<Candidato> candidatos)
    {
        var result = new List<CandidatoCommandResult>();
        var tecnologias = new List<TecnologiaCommandResult>();

        foreach (var candidato in candidatos)
        {
            if (candidato.CandidatoTecnologias != null)
                foreach (var tec in candidato.CandidatoTecnologias)
                    if (tec.Tecnologia != null)
                        tecnologias.Add(new TecnologiaCommandResult().MontaTecnologia(tec.Tecnologia));
                    else
                        tecnologias.Add(new TecnologiaCommandResult(tec.TecnologiaId));

            result.Add(new CandidatoCommandResult(
                candidato.Id,
                candidato.Nome,
                candidato.Funcao,
                tecnologias,
                candidato.Ativo));
        }
        return result;
    }
}
