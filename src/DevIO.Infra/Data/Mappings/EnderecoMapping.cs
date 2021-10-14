using DevIO.Bussines.Models.Fornecedores;
using System.Data.Entity.ModelConfiguration;

namespace DevIO.Infra.Data.Mappings
{
    public class EnderecoMapping : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMapping()
        {
            HasKey(e => e.Id);

            Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(200);

            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.Cep)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();

            Property(e => e.Complemento)
                .IsRequired()
                .HasMaxLength(250);

            Property(e => e.Bairro)
                .IsRequired();

            Property(e => e.Cidade)
                .IsRequired();

            Property(e => e.Estado)
                .IsRequired();

            ToTable("Enderecos");
        }
    }
}
