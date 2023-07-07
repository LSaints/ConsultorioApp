using ConsultorioApp.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsultorioApp.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);
            builder.ToTable("Tb_Clientes");
            builder.Property(c => c.Name).HasColumnName("Nome").HasMaxLength(200).IsRequired();
            builder.Property(c => c.Sexo).HasDefaultValue('M').IsRequired();
            builder.Property(c => c.Documento).HasColumnName("DocumentoIndetificador").IsRequired();

            builder.HasIndex(c => new { c.Name, c.Sexo });

            builder.Property(c => c.DataNascimento).HasColumnType("varchar");
        }
    }
}
