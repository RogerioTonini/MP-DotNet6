using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByAsync(int id);

    }
}
