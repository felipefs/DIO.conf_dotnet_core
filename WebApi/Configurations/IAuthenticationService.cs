using WebApi.Models.Usuarios;

namespace WebApi.Configurations
{
   public interface IAuthenticationService
   {
      string GerarToken(UsuarioViewModelOutput usuarioViewModelOutput);
   }
}