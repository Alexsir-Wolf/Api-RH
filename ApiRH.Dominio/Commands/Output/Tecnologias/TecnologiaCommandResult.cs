using ApiRH.Dominio.Entidades;

namespace ApiRH.Dominio.Commands.Output.Tecnologias;

public class TecnologiaCommandResult
{
    public TecnologiaCommandResult()
    {
    }
    public TecnologiaCommandResult(
        string? nome,
        string? peso,
        bool ativo)
    {
        Nome = nome;
        Peso = peso;
        Status = ativo ? "Ativo" : "Inativo";
    }

    public string? Nome { get; private set; }
    public string? Peso { get; private set; }
    public string? Status { get; private set; }

    public TecnologiaCommandResult MontaTecnologia(Tecnologia? command)
    {
        return new TecnologiaCommandResult(
            command.Nome, 
            command.Peso, 
            command.Ativo);
    }
}
