using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MP.ApiDotNet6.Domain.Entities;


namespace MP.ApiDotNet6.Infra.Data.Maps
{
    internal class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            // Mapeando a Tabela qdo os nomes das Entidades são diferentes do nome das colunas do DB
            builder.ToTable("COMPRA");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductId)
                .HasColumnName("IDPRODUTO");

            builder.Property(x => x.PersonId)
                .HasColumnName("IDPESSOA");

            builder.Property(x => x.DatePurchase)
                .HasColumnName("DATACOMPRA");

            // Cria o relacionamento entre as tabelas, definindo o tipo de relacionamento 1 para N
            builder.HasOne(x => x.Person)
                   .WithMany(x => x.Purchase);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Purchase);
        }
    }
}
