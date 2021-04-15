using Microsoft.EntityFrameworkCore;
using WebApi.Business.Entities;

namespace WebApi.Infraestruture.Data.Mappings
{
   public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
   {
      void IEntityTypeConfiguration<Usuario>.Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Usuario> builder)
      {
         builder.ToTable("TB_USUARIO");
         builder.HasKey(p => p.Codigo);
         builder.Property(p => p.Codigo).ValueGeneratedOnAdd();
         builder.Property(p => p.Login);
         builder.Property(p => p.Senha);
         builder.Property(p => p.Email);
      }
   }
}