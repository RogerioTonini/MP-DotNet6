using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Infra.Data.Maps
{
    internal class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            // Mapeando a Tabela qdo os nomes das Entidades são diferentes do nome das colunas do DB
            builder.ToTable("TB_PESSOA");

            builder.HasKey(c => c.Id);

            // ATENÇÃO: No projeto original (YOUTUBE) só o primeiro caracter é maiúsculo
            builder.Property(c => c.Name)
                .HasColumnName("ID_PESSOA")
                .UseIdentityColumn();

            builder.Property(c => c.Document)
                .HasColumnName("DOCUMENTO");

            builder.Property(c => c.Name)
                .HasColumnName("NOME");

            builder.Property(c => c.PhoneCel)
                .HasColumnName("CELULAR");

            /*
             * Cria o relacionamento entre as tabelas, definindo o tipo de relacionamento 1 para N
             *
             * Tabela de Pessoa tem uma lista de Compras (.HasMany), onde essa lista de Compras possui
             * um atributo virtual (.WithOne) e sua chave estrangeira é (HasForeignKey)
             */
            builder.HasMany(c => c.Purchase)
                .WithOne(p => p.Person)
                .HasForeignKey(c => c.PersonId);
        }
    }
}
