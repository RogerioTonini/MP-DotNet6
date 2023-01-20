namespace MP.ApiDotNet6.Application.DTOs
{
    // Fará a ponte entre a aplicação e o usuário ao digitar os dados
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document {get; set;}
        public string PhoneCel { get; set; }
    }
}
