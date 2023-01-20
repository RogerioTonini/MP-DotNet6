﻿namespace MP.ApiDotNet6.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        // Este construtor recebe da classe PAI as informações para conexão ao DB
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        /*
         * Mapear a entidade criada no Projeto DOMAIN, classe PERSON
         * Para mapear a entidade é obrigatório utilizar a clausula:
         * using MP.ApiDotNet6.Domain.Entities;
         * 
         * Como o nome das colunas no DB estão diferentes das Entidades
         * será necessário mapear os campos.
         * Para realizar este procedimentos foi criada uma pasta chamada Maps
         * e dentro dela será criada uma classe para cada Tabela da aplicação
         */
        public DbSet<Person> Tb_Pessoa { get; set; }
        public DbSet<Product> Tb_Product { get; set; }
        public DbSet<Purchase> Tb_Purchase { get; set; }
        /*
         * Método que sobre escreve as configurações DESTA CLASSE.
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
