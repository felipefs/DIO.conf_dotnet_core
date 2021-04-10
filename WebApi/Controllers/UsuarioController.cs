using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Models.Usuarios;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
      
        [HttpPost]
        public IActionResult Logar(LoginViewModelInput _loginViewModelInput){

            return Created("", _loginViewModelInput);
        }

        
        public IActionResult Registrar(RegistrarViewModelInput _registrarViewModelInput){

            return Created("", _registrarViewModelInput);
        }

       
    }
}
