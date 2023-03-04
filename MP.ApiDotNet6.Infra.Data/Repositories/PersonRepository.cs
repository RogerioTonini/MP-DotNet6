using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;
using MP.ApiDotNet6.Infra.Data.Repositories;


namespace MP.ApiDotNet6.Infra.Data.Repositories
{
    // Implementando as Assinaturas que a Interface IPersonRepository possue
    public class PersonRepository : IPersonRepository
    {
        // Implementação concreta dos métodos da Interface

        private readonly ApplicationDbContext _db;

        // Classe herda todos os métodos da classe ApplicationDbContext
        public PersonRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        // Função da classe: Salva o registro na tabela e o devolve
        public async Task<Person> CreateAsync(Person person)
        {
            _db.add(person);
            await _db.SaveChangesAsync();
            return person;
        }

        //public async Task<Person> CreateAsync(Person person)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task DeleteAsync(Person person)
        {
            _db.Remove(person);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Person person)
        {
            _db.Update(person);
            await _db.SaveChangesAsync();
        }

        // Retorna a consulta de um registro
        public async Task<Person> GetByIdAsync(int id)
        {
            return await _db.People.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Person>> GetPeopleAsync()
        {
            return await _db.People.ToListAAsync();
        }
    }
}
