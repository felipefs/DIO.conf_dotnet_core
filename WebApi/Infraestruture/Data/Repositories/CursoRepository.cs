using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApi.Business.Entities;
using WebApi.Business.Repositories;

namespace WebApi.Infraestruture.Data.Repositories
{
   public class CursoRepository : ICursoRepository
   {
      private readonly CursoDbContext _context;
      public CursoRepository(CursoDbContext context)
      {
         this._context = context;
      }

      public void Adicionar(Curso curso)
      {
         _context.Curso.Add(curso);
      }

      public void Commit()
      {
         _context.SaveChanges();
      }

      public IList<Curso> ObterPorUsuario(int CodUsuario)
      {
         return _context.Curso
            .Include(i => i.Usuario)
            .Where(w => w.CodigoUsuario == CodUsuario).ToList();
      }
   }
}