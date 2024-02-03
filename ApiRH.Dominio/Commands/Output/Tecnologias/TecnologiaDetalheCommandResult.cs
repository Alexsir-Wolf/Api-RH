using ApiRH.Dominio.Entidades;

namespace ApiRH.Dominio.Commands.Output.Tecnologias;

public class TecnologiaDetalheCommandResult
{
    public TecnologiaDetalheCommandResult()
    {            
    }

    public TecnologiaDetalheCommandResult(
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

    public TecnologiaDetalheCommandResult MontarTecnologia(Tecnologia tecnologia)
    {
        return new TecnologiaDetalheCommandResult(
            tecnologia.Id,
            tecnologia.Nome,
            tecnologia.Peso,
            tecnologia.Ativo);
    }
}
