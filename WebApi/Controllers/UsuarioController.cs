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

            var usuarioViewModelOutput = new UsuarioViewModelOutput(){
                Codigo ="1",
                Login="fe",
                Email = "f@" 
            };
            
            var secret = Encoding.ASCII.GetBytes("KJsmjfk375Mj3874nd-0ssd\\dsdsd-0");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity( new Claim[]{
                    new Claim( ClaimTypes.NameIdentifier, usuarioViewModelOutput.Codigo.ToString()),
                    new Claim( ClaimTypes.Name, usuarioViewModelOutput.Login.ToString()),
                    new Claim( ClaimTypes.Email, usuarioViewModelOutput.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);
            
            return Ok(new
                {
                    Token = token,
                    Usuario = _loginViewModelInput
                }
            );
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
