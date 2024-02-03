using ApiRH.Dominio.Commands.Input.Tecnologias;
using ApiRH.Dominio.Commands.Output.Tecnologias;
using ApiRH.Dominio.Core.Commands;

namespace ApiRH.Dominio.Contratos.Handlers
{
    public interface ITecnologiaHandler
    {
        Task<CommandResult<TecnologiaCommandResult>> RegistrarTecnologia(TecnologiaCommand command);
        Task<CommandResult<TecnologiaCommandResult>> AlterarTecnologia(int id, TecnologiaCommand command);
        Task<CommandResult<List<TecnologiaCommandResult>>> ListarTecnologias();
        Task<CommandResult<TecnologiaDetalheCommandResult>> ObterTecnologiaPorId(int id);
        Task<CommandResult<object>> ExcluirTecnologia(int id);
    }
}
