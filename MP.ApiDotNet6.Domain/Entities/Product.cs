using MP.ApiDotNet6.Domain.Validations;

namespace MP.ApiDotNet6.Domain.Entities
{
    /* Esta classe será Sealed (é usada para impedir que a classe seja herdada por outras classes.
     * O modificador "sealed" também pode ser usado com métodos para evitar que os métodos sejam 
     * sobrescritos nas classes filhas.) */
    public sealed class Product
    {
        // Criação de atributos
        // Entenda como <private set> para que não sejam acessados fora da classe
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal Price { get; private set; }

        // Criando o relacionamento de 1 para N Person (Pessoa)
        public ICollection<Purchase> Purchases { get; set; }

        /* Construtor que valida as informações fornecidas pelo usuário.
         * Utilização: INSERT */
        public Product(string name, string coderp, decimal price)
        {
            ProductValidation(name, coderp, price);
            Purchases = new List<Purchase>();
        }

        /* Construtor que valida as informações fornecidas pelo usuário.
         * Utilização: UPDATE */
        public Product(int id, string name, string coderp, decimal price)
        {
            DomainValidationException.When(Id < 0, "ID inválido!");
            Id = id;
            ProductValidation(name, coderp, price);
            Purchases = new List<Purchase>();
        }

        // Método responsável pelas validações das informações, de acordo com as REGRAS DE NEGÓCIO.
        private void ProductValidation(string name, string coderp, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(coderp), "Código ERP deve ser informado!");
            DomainValidationException.When(price < 0, "Valor deve ser informado!");

            Name = name;
            CodErp = coderp;
            Price = price;
        }
    }
}
