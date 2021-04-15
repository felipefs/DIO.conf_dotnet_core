using Microsoft.EntityFrameworkCore;
using WebApi.Business.Entities;

namespace WebApi.Infraestruture.Data.Mappings
{
   public class CursoMapping : IEntityTypeConfiguration<Curso>
   {
      public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Curso> builder)
      {
         builder.ToTable("TB_CURSO");
         builder.HasKey(p => p.Codigo);
         builder.Property(p => p.Codigo).ValueGeneratedOnAdd();
         builder.Property(p => p.Descricao);
         builder.Property(p => p.Nome);
         builder.HasOne(p => p.Usuario).WithMany()
            .HasForeignKey(fk => fk.CodigoUsuario);
         
      }
   }
}