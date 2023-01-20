namespace MP.ApiDotNet6.Domain.Validations
{
    // Classe herda a classe EXCEPTION (erros)
    public class DomainValidationException : Exception
    {
        // Recebe a string de ERRO junto a classe herdada EXCEPTION
        public DomainValidationException (string error) : base(error)
        {
        }

        // Criação do método para validar a EXCESSÃO recebida, sendo VERDADEIRA, lança a execessão.
        // Este método é de validação genérica.
        public static void When(bool hasError, string message)
        {
             if (hasError)
                  throw new DomainValidationException (message);
        }
    }
}
