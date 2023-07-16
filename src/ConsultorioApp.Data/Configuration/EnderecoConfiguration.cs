using ConsultorioApp.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsultorioApp.Data.Configuration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.ClienteId);
            builder.Property(p => p.Estado).HasConversion(
                p => p.ToString(),
                p => (Estado)Enum.Parse(typeof(Estado), p));
        }
    }
}
