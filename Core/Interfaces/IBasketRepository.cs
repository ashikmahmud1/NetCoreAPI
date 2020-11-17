using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBasketRepository
    {
         // create, read, update, delete basket from redis

         Task<CustomerBasket> GetBasketAsync(string basketId);

         Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);

         Task<bool> DeleteBasketAsync(string basketId);
    }
}