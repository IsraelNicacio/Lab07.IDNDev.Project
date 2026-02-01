using IDNDev.Cadastro.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IDNDev.Cadastro.Api.Data;

internal class PessoaMapping : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.HasKey(k => k.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(60)");

        builder.Property(p => p.Documento)
            .IsRequired()
            .HasColumnType("varchar(14)");

        builder.Property(p => p.Idade)
            .IsRequired()
            .HasColumnType("integer");

        builder.ToTable("Pessoas", "Cadastros");
    }
}
