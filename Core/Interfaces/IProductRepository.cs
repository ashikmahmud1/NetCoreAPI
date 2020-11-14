using System.Collections.Generic;
using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
         Task<Product> GetProductByIdAsync(int id);

         Task<IReadOnlyList<Product>> GetProductsAsync();
    }
}