using ApiRH.Dominio.Commands.Input.Vagas;
using ApiRH.Dominio.Commands.Output.Vagas;
using ApiRH.Dominio.Contratos.Handlers;
using ApiRH.Dominio.Contratos.Repositorios;
using ApiRH.Dominio.Core.Commands;
using ApiRH.Dominio.Entidades;
using System.Net;

namespace ApiRH.Dominio.Handlers;

public class VagaHandler : IVagaHandler
{
    private readonly IVagaRepositorio _vagaRepositorio;
    public VagaHandler(IVagaRepositorio vagaRepositorio)
    {
        _vagaRepositorio = vagaRepositorio;
    }

    public async Task<CommandResult<VagaCommandResult>> RegistrarVaga(VagaCommand command) 
    {
        try
        {
            var result = new CommandResult<VagaCommandResult>(HttpStatusCode.UnprocessableEntity.GetHashCode());

            if (!command.IsValid()) 
            {
                result.AddNotificacoes(command);
                return result;
            }

            var vaga = new Vaga().MontarVaga(command);
            await _vagaRepositorio.InserirAsync(vaga);

            return new CommandResult<VagaCommandResult>(HttpStatusCode.Created.GetHashCode())
            {
                Data = new VagaCommandResult().MontaVaga(vaga),
                Mensagem = "Vaga criada com sucesso!"
            };          
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CommandResult<List<VagaCommandResult>>> ListarVagas()
    {
        try
        {
            var vagas = await _vagaRepositorio.ListarVagas();

            return new CommandResult<List<VagaCommandResult>>(HttpStatusCode.OK.GetHashCode())
            {
                Data = new VagaCommandResult().MontarLista(vagas),
            };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CommandResult<VagaCommandResult>> AlterarVaga(int id, VagaCommand command)
    {
        try
        {
            var result = new CommandResult<VagaCommandResult>(HttpStatusCode.UnprocessableEntity.GetHashCode());
            if (!command.IsValid())
            {
                result.AddNotificacoes(command);
                return result;
            }

            var vaga = await _vagaRepositorio.ObterVagaPorId(Convert.ToInt32(id));
            vaga.MontaAlteracao(command);

            await _vagaRepositorio.AlterarVaga(id, vaga);

            return new CommandResult<VagaCommandResult>(HttpStatusCode.OK.GetHashCode())
            {
                Data = new VagaCommandResult().MontaVaga(vaga),
                Mensagem = "Vaga alterada com sucesso!"
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<CommandResult<VagaDetalheCommandResult>> ObterVagaPorId(int id)
    {
        try
        {
            var vaga = await _vagaRepositorio.ObterVagaPorId(id);

            if (vaga != null)
            {
                return new CommandResult<VagaDetalheCommandResult>(HttpStatusCode.OK.GetHashCode())
                {
                    //Data = new VagaDetalheCommandResult().MontarVaga(vaga),
                };
            }

            return new CommandResult<VagaDetalheCommandResult>(HttpStatusCode.NotFound.GetHashCode())
            {
                Data = new VagaDetalheCommandResult(),
                Mensagem = "Vaga não encontrada!"
            };            
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CommandResult<object>> ExcluirVaga(int id)
    {
        try
        {
            await _vagaRepositorio.DeleteAsync(id);
            return new CommandResult<object>(HttpStatusCode.OK.GetHashCode())
            {
                Mensagem = "Vaga excluída com sucesso!"
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
