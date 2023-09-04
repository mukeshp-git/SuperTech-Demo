using SupremTech.Domain;

namespace SupremTech.Repositories.Contracts
{
    public interface IProductRepository
    {
        public IList<Product> GetProduct(int id);
    }
}
