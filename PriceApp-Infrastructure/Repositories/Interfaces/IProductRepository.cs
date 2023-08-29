using PriceApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<Product> FindProductById(int id, bool trackChanges);
        Task<Product> FindProductByName(string productName, bool trackChanges);
        Task<IEnumerable<Product>> FindProductByKeyWord(string keyword, bool track);
      /*  IQueryable<Product> FindProductByPrice(decimal price, bool trackChanges);
        IQueryable<Product> FindProductByPriceRange(decimal price, bool trackChanges);*/
    }
}
