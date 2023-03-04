using MP.ApiDotNet6.Domain.Validations;

namespace MP.ApiDotNet6.Domain.Entities
{
    /* Esta classe será Sealed (é usada para impedir que a classe seja herdada por outras classes.
     * O modificador "sealed" também pode ser usado com métodos para evitar que os métodos sejam 
     * sobrescritos nas classes filhas.) */
    public sealed class Person
    {
        // Criação de atributos
        // Entenda como <private set> para que não sejam acessados fora da classe
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string PhoneCel { get; private set; }

        // Criando o relacionamento de 1 para N Purchase (Compra)
        public ICollection<Purchase> Purchases { get; set; }

        /* Construtor que valida as informações fornecidas pelo usuário.
         * Utilização: INSERT */
        public Person(string name, string document, string phonecel)
        {
            PersonValidation(name, document, phonecel);
            Purchases = new List<Purchase>();
        }

        /* Construtor que valida as informações fornecidas pelo usuário.
         * Utilização: UPDATE */
        public Person(int id, string name, string document, string phonecel)
        {
            DomainValidationException.When(Id < 0, "ID inválido!");
            Id = id;
            PersonValidation(name, document, phonecel);
            Purchases = new List<Purchase>();
        }

        // Método responsável pelas validações das informações, de acordo com as REGRAS DE NEGÓCIO.
        private void PersonValidation(string name, string document, string phonecel)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(document), "Documento deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(phonecel), "Celular deve ser informado!");

            Document = document;
            Name = name;
            PhoneCel = phonecel;
        }
    }
}
