using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Models.Usuarios;
using Swashbuckle.AspNetCore.Annotations;
using WebApi.Models;
using WebApi.Filters;

namespace WebApi.Controllers
{

    /// <summary>
    /// UsuarioController
    /// </summary>
    /// <param ></param>
    /// <returns></returns>
    [ApiController]
    [Route("api/v1/usuario")]
    public class UsuarioController : ControllerBase
    {
      
        /// <summary>
        /// Logar
        /// </summary>
        /// <param name="_loginViewModelInput"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode:200, description:"Sucesso ao autenticar", Type=typeof(LoginViewModelInput) )]
        [SwaggerResponse(statusCode:400, description:"Campos Obrigatórios", Type=typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode:500, description:"Erro interno", Type=typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Logar(LoginViewModelInput _loginViewModelInput){

            
           // if(!ModelState.IsValid){
           //     return BadRequest(new ValidaCampoViewModelOutput(ModelState.SelectMany(sm => sm.Value.Errors).Select(s=> s.ErrorMessage)));
           // }
            
            return Ok(_loginViewModelInput);
        }

        
        /// <summary>
        /// Registrar
        /// </summary>
        /// <param name="_registrarViewModelInput"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("registrar")]
        [ValidacaoModelStateCustomizado]        
        public IActionResult Registrar(RegistroViewModelInput _registrarViewModelInput){

            return Created("", _registrarViewModelInput);
        }

       
    }
}
