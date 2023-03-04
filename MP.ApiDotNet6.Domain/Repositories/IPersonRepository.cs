using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Domain.Repositories
{
    public interface IPersonRepository
    {
        /*
         * Criação das assinaturas dos 5 métodos padrão:
         * Cadastrar, Editar, Deletar, Pesquisa: uma e todas as pessoas
         */
        Task<Person> GetByIdAsync(int id);
        Task<ICollection<Person>> GetPeopleAsync();
        Task<Person> CreateAsync(Person person);
        Task EditAsync(Person person);
        Task DeleteAsync(Person person);
    }

}
