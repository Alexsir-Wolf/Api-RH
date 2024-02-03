using ApiRH.Dominio.Entidades;

namespace ApiRH.Dominio.Commands.Output.Tecnologias;

public class TecnologiaCommandResult
{
    public TecnologiaCommandResult()
    {
    }
    public TecnologiaCommandResult(
        int? id,
        string? nome,
        string? peso,
        bool ativo)
    {
        Id = id;
        Nome = nome;
        Peso = peso;
        Status = ativo ? "Ativo" : "Inativo";
    }

    public int? Id { get; private set; }
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
}
