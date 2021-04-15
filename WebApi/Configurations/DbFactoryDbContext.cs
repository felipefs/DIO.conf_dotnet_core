using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebApi.Infraestruture.Data;

namespace WebApi.Configurations
{
   public class DbFactoryDbContext : IDesignTimeDbContextFactory<CursoDbContext>
   {
      public CursoDbContext CreateDbContext(string[] args)
      {
            var optionsBuilder = new DbContextOptionsBuilder<CursoDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost; database=CURSO; Id=sa;Password=Tt53poisa@ ");

            
            CursoDbContext context = new CursoDbContext(optionsBuilder.Options);
            return context;

      }
   }
}