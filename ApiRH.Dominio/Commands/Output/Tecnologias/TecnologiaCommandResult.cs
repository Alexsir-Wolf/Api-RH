using ApiRH.Dominio.Entidades;

namespace ApiRH.Dominio.Commands.Output.Tecnologias;

public class TecnologiaCommandResult
{
    public TecnologiaCommandResult()
    {
    }

    public TecnologiaCommandResult(int? tecnologiaId)
    {
        TecnologiaId = tecnologiaId;
    }

    public TecnologiaCommandResult(
        int? tecnologiaId,
        string? nome,
        string? peso,
        bool ativo)
    {
        TecnologiaId = tecnologiaId;
        Nome = nome;
        Peso = peso;
        Status = ativo ? "Ativo" : "Inativo";
    }

    public int? TecnologiaId { get; private set; }
    public string? Nome { get; private set; }
    public string? Peso { get; private set; }
    public string? Status { get; private set; }

    public TecnologiaCommandResult MontaTecnologia(Tecnologia? command)
    {
        return new TecnologiaCommandResult(
            command.Id,
            command.Nome, 
            command.Peso, 
            command.Ativo);
    }

    public List<TecnologiaCommandResult> MontarLista(IQueryable<Tecnologia> tecnologias)
    {
        var result = new List<TecnologiaCommandResult>();

        foreach (var tec in tecnologias)
        {
            result.Add(new TecnologiaCommandResult(
                tec.Id,
                tec.Nome,
                tec.Peso,
                tec.Ativo));
        }
        return result;
    }

    public List<TecnologiaCommandResult> AdicionarTecnologias(List<EmpresaTecnologia> empresaTecnologias)
    {
        var tecnologias = new List<TecnologiaCommandResult>();

        if (empresaTecnologias != null)
        {

            foreach (var tec in empresaTecnologias)
            {
                if (tec.Tecnologia == null)
                {
                    tecnologias.Add(new TecnologiaCommandResult(tec.TecnologiaId));
                }
                else 
                {
                    tecnologias.Add(new TecnologiaCommandResult(
                        tec.Tecnologia.Id,
                        tec.Tecnologia.Nome,
                        tec.Tecnologia.Peso,
                        tec.Tecnologia.Ativo));
                }  
            }
        }
        return tecnologias;
    }
}
