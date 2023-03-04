namespace MP.ApiDotNet6.Infra.Data.Maps
{
    internal class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Mapeando a Tabela qdo os nomes das Entidades são diferentes do nome das colunas do DB
            builder.ToTable("PRODUTO");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IDPRODUTO")
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnName("NOME");

            builder.Property(x => x.CodErp)
                .HasColumnName("CODERP");

            builder.Property(x => x.Price)
                .HasColumnName("PRECO");

            // Cria o relacionamento entre as tabelas, definindo o tipo de relacionamento 1 para N
            builder.HasMany(x => x.Purchase)
                .WithOne(p => p.Product)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
