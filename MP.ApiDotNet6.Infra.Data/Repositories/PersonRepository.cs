using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotNet6.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
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

        public async Task<Person> IPersonRepository.CreateAsync(Person person)
        {
            throw new NotImplementedException();
        }

        public async Task IPersonRepository.DeleteAsync(Person person)
        {
            _db.Remove(person);
            await _db.SaveChangesAsync();
        }

        public async Task IPersonRepository.EditAsync(Person person)
        {
            _db.Update(person);
            await _db.SaveChangesAsync();
        }

        public async Task<Person> IPersonRepository.GetByIdAsync(int id)
        {
            return await _db.People.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Person>> IPersonRepository.GetPeopleAsync()
        {
            return await _db.People.ToListAAsync();
        }
    }
}
