using WebApi.Business.Entities;

namespace WebApi.Business.Repositories
{
   public interface IUsuarioRepository
   {
      void Adicionar(Usuario usuario);
      void Commit();
      Usuario ObterUsuario(string login);
   }
}