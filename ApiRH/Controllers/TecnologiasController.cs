using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ApiRH.Controllers.Base;
using ApiRH.Dominio.Core.Commands;
using ApiRH.Dominio.Contratos.Handlers;
using ApiRH.Dominio.Commands.Input.Tecnologias;
using ApiRH.Dominio.Commands.Output.Tecnologias;

namespace ApiRH.Controllers
{
    public class TecnologiasController : BaseController
    {
        private readonly ITecnologiaHandler _tecnologiaHandler;

        public TecnologiasController(ITecnologiaHandler tecnologiaHandler)
        {
            _tecnologiaHandler = tecnologiaHandler;                
        }

        /// <summary>
        /// Cria uma nova tecnologia.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     {
        ///        "Nome": "RH",
        ///        "peso": "RH"
        ///     }
        ///
        /// </remarks>
        /// <returns>Uma nova tecnologia foi criada.</returns>
        /// <response code="201">Retorna a nova tecnologia criada.</response>
        /// <response code="400">Se a nova tecnologia não for criada.</response>    
        [HttpPost]
        [Produces("application/json")]
        [SwaggerResponse(201, Type = typeof(CommandResult<TecnologiaCommandResult>))]
        public async Task<CommandResult<TecnologiaCommandResult>> Registrar(TecnologiaCommand command)
        {
            return await _tecnologiaHandler.RegistrarTecnologia(command);
        }

    }
}
