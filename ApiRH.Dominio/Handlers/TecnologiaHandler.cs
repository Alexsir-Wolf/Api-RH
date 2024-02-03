using ApiRH.Dominio.Commands.Input.Tecnologias;
using ApiRH.Dominio.Commands.Output.Tecnologias;
using ApiRH.Dominio.Contratos.Handlers;
using ApiRH.Dominio.Core.Commands;
using ApiRH.Dominio.Entidades;
using System.Net;

namespace ApiRH.Dominio.Handlers;

public class TecnologiaHandler : ITecnologiaHandler
{
    private readonly ITecnologiaRepositorio _tecnologiaRepositorio;
    public TecnologiaHandler(ITecnologiaRepositorio tecnologiaRepositorio)
    {
        _tecnologiaRepositorio = tecnologiaRepositorio;
    }

    public async Task<CommandResult<TecnologiaCommandResult>> RegistrarTecnologia(TecnologiaCommand command) 
    {
        try
        {
            var result = new CommandResult<TecnologiaCommandResult>(HttpStatusCode.UnprocessableEntity.GetHashCode());

            if (!command.IsValid()) 
            {
                result.AddNotificacoes(command);
                return result;
            }

            var tecnologia = new Tecnologia(command.Nome, command.Peso);
            await _tecnologiaRepositorio.InserirAsync(tecnologia);

            return new CommandResult<TecnologiaCommandResult>(HttpStatusCode.Created.GetHashCode())
            {
                Data = new TecnologiaCommandResult().MontaTecnologia(tecnologia),
                Mensagem = "Tecnologia criada com sucesso!"
            };          
        }
        catch (Exception)
        {
            throw;
        }
    }

}
