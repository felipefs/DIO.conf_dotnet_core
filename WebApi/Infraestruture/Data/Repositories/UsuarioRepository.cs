using System.Linq;
using WebApi.Business.Entities;
using WebApi.Business.Repositories;

namespace WebApi.Infraestruture.Data.Repositories
{
   public class UsuarioRepository : IUsuarioRepository
   {
      private readonly CursoDbContext _context;
      public UsuarioRepository(CursoDbContext context)
      {
         this._context = context;
      }

      public void Adicionar(Usuario usuario)
      {
         _context.Usuario.Add(usuario);
         
      }

      public void Commit()
      {
         _context.SaveChanges();
      }

      public Usuario ObterUsuario(string login)
      {
         return _context.Usuario.FirstOrDefault(u => u.Login == login);
      }
   }
}