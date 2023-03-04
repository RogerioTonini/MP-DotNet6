using MP.ApiDotNet6.Domain.Validations;

namespace MP.ApiDotNet6.Domain.Entities
{
    /* Esta classe será Sealed (é usada para impedir que a classe seja herdada por outras classes.
     * O modificador "sealed" também pode ser usado com métodos para evitar que os métodos sejam 
     * sobrescritos nas classes filhas.) */
    public sealed class Purchase
    {
        // Criação de atributos
        // Confira-se como <private set> para que não sejam acessados fora da classe
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime DatePurchase { get; private set; }
        /*
         * Declaração de classes virtuais Person e Purchase.
         * 
         * Regra de Negócio:
         * Uma Purchase (compra) necessita de uma Person (pessoa) e um Product (produto)
         * Uma Person(pessoa) poderá ter vários Product (produto) Purchase (comprados) em várias datas
         * 
         * Desta forma criaremos o relacionamento de 1 para N.
         */
        public Person Person { get; set; }
        public Product Product { get; set; }

        /* Construtor que valida as informações fornecidas pelo usuário.
         * Utilização: INSERT */
//#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Purchase(int productId, int personId, DateTime? datePurchase)
//#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            PurchaseValidation(productId, personId, datePurchase);
        }

        /* Construtor que valida as informações fornecidas pelo usuário.
         * Utilização: UPDATE */
//#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Purchase(int id, int productId, int personId, DateTime? datePurchase)
//#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            DomainValidationException.When(Id < 0, "ID inválido!");
            Id = id;
            PurchaseValidation(productId, personId, datePurchase);
        }

        // Método responsável pelas validações das informações, de acordo com as REGRAS DE NEGÓCIO.
        private void PurchaseValidation(int productId, int personId, DateTime? date)
        {
            DomainValidationException.When(productId < 0, "Id do Produto deve ser informado!");
            DomainValidationException.When(personId < 0, "Id do Cliente deve ser informado!");
            DomainValidationException.When(!date.HasValue, "Data da compra deve ser informada!");

            ProductId = productId;
            PersonId = personId;
            DatePurchase = DateTime.Now;
        }
    }
}
