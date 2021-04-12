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
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Models.Cursos;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{

    /// <summary>
    /// UsuarioController
    /// </summary>
    /// <param ></param>
    /// <returns></returns>
    [ApiController]
    [Route("api/v1/cursos")]
    [Authorize]
    public class CursoController : ControllerBase
    {
      
        /// <summary>
        /// Permite cadastrar um curso
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [SwaggerResponse(statusCode:201, description:"Sucesso ao cadastrar curso", Type=typeof(CursoViewModelInput) )]
        [SwaggerResponse(statusCode:401, description:"Não autorizado", Type=typeof(CursoViewModelInput))]
        public async Task<IActionResult> Post(CursoViewModelInput _cursoViewModelInput){
            
            var codigoUsuario = int.Parse(User.FindFirst(c=> c.Type== ClaimTypes.NameIdentifier)?.Value);
            return Created("",_cursoViewModelInput);
        }

        /// <summary>
        /// Este serviço permite obter todos os cursos ativos do usuário
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [SwaggerResponse(statusCode:200, description:"Sucesso ao obter curso", Type=typeof(CursoViewModelInput) )]
        [SwaggerResponse(statusCode:401, description:"Não autorizado", Type=typeof(CursoViewModelInput))]
        public async Task<IActionResult> Get(){
            

            //var codigoUsuario = int.Parse(User.FindFirst(c=> c.Type== ClaimTypes.NameIdentifier)?.Value);
            var cursos = new List<CursoViewModelOutput>();
            cursos.Add(new CursoViewModelOutput(){
                Descricao ="teste",
                Nome="teste",
                Login = ""

            });
            return Ok(cursos);
        }


       
    }
}
