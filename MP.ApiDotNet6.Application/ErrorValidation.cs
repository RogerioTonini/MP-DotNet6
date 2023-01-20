namespace MP.ApiDotNet6.Application
{
    /*
     * Classe responsável por tratar os retornos erros ou sucesso no cadastro
     */
    public class ErrorValidation
    {
        /* Criação de 2 atributos para receber o Campo e a Mensagem.
        * O .NET CORE 6 reclama que este campo não aceita nulo, caso queira aceitar basta colocar
        *  o caracter ? logo a seguir da definição do tipo do nome do atributo: string$
        */
        public string Field { get; set; }
        public string Message { get; set; }
    }
}
