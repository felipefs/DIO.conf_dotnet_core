using System.Collections.Generic;
using WebApi.Business.Entities;

namespace WebApi.Business.Repositories
{
    public interface ICursoRepository
    {
         void Adicionar(Curso curso);
         void Commit();
         IList<Curso> ObterPorUsuario(int CodUsuario);
    }
}