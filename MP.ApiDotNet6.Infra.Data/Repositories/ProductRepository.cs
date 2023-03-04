namespace MP.ApiDotNet6.Infra.Data.Repositories
{
    public class ProductRepository
    {
        public class ProductRepository : IProductRepository
        {
            private readonly ApplicationDbContext _db;

            // Classe herda todos os métodos da classe ApplicationDbContext
            public ProductRepository(ApplicationDbContext db)
            {
                _db = db;
            }

            // Função da classe: Salva o registro na tabela e o devolve
            public async Task<Product> CreateAsync(Product product)
            {
                _db.add(product);
                await _db.SaveChangesAsync();
                return product;
            }

            //public async Task<Product> CreateAsync(Product product)
            //{
            //    throw new NotImplementedException();
            //}

            public async Task DeleteAsync(Product product)
            {
                _db.Remove(product);
                await _db.SaveChangesAsync();
            }

            public async Task EditAsync(Product product)
            {
                _db.Update(product);
                await _db.SaveChangesAsync();
            }

            public async Task<Product> GetByIdAsync(int id)
            {
                return await _db.People.FirstOrDefaultAsync(x => x.Id == id);
            }

            public async Task<ICollection<Product>> GetProductAsync()
            {
                return await _db.Product.ToListAsync();
            }
        }
    }
}
