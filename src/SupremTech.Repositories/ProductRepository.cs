

using SupremTech.Domain;
using SupremTech.EntityFrameworkCore;
using SupremTech.Repositories.Contracts;

namespace SupremTech.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _context;
        public IList<Product> GetProduct(int id)
        {
            IList<Product> lstProduct = null;

            lstProduct = _context.ProductsSet.Where(product =>
                             product.ProductID == id).ToList();
            return lstProduct;
        }

    }
}