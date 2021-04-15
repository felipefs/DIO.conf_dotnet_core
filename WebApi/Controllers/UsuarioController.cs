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
using WebApi.Infraestruture.Data;
using Microsoft.EntityFrameworkCore;
using WebApi.Business.Entities;
using WebApi.Business.Repositories;
using Microsoft.Extensions.Configuration;
using WebApi.Configurations;

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

      private readonly IUsuarioRepository _usuarioRepository;
      private readonly IAuthenticationService _authenticationService;

      public UsuarioController(
          IUsuarioRepository usuarioRepository,
          IAuthenticationService authenticationService
          )
      {
         _usuarioRepository = usuarioRepository;

         _authenticationService = authenticationService;
      }

      /// <summary>
      /// Logar
      /// </summary>
      /// <param name="_loginViewModelInput"></param>
      /// <returns></returns>
      [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
      [SwaggerResponse(statusCode: 400, description: "Campos Obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
      [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
      [HttpPost]
      [Route("logar")]
      [ValidacaoModelStateCustomizado]
      public IActionResult Logar(LoginViewModelInput _loginViewModelInput)
      {

         var usuario = _usuarioRepository.ObterUsuario(_loginViewModelInput.Login);

        if (usuario == null){
            return BadRequest("Houve um erro ao tentar acessar");
        }

         var usuarioViewModelOutput = new UsuarioViewModelOutput()
         {
            Codigo = usuario.Codigo,
            Login = _loginViewModelInput.Login,
            Email = usuario.Email
         };


         string token = _authenticationService.GerarToken(usuarioViewModelOutput);

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
      /// <param name="_registrarViewModelInput">View model de Registro</param>
      /// <returns></returns>
      [SwaggerResponse(statusCode: 200, description: "Sucesso ao registrar", Type = typeof(RegistroViewModelInput))]
      [SwaggerResponse(statusCode: 400, description: "Campos Obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
      [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
      [HttpPost]
      [Route("registrar")]
      [ValidacaoModelStateCustomizado]
      public IActionResult Registrar(RegistroViewModelInput _registrarViewModelInput)
      {


         //var migracoesPendentes = context.Database.GetPendingMigrations();
         //if (migracoesPendentes.Count()>0){
         //    context.Database.Migrate();
         //}
         var usuario = new Usuario();
         usuario.Login = _registrarViewModelInput.Login;
         usuario.Senha = _registrarViewModelInput.Senha;
         usuario.Email = _registrarViewModelInput.Email;

         _usuarioRepository.Adicionar(usuario);
         _usuarioRepository.Commit();

         return Created("", _registrarViewModelInput);
      }


   }
}
