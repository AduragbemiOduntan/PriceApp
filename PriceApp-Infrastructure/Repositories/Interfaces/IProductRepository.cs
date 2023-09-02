using PriceApp_Domain.Entities;

namespace PriceApp_Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<Product> FindProductById(int id, bool trackChanges);
        Task<Product> FindProductByName(string productName, bool trackChanges);
        Task<IEnumerable<Product>> FindProductByKeyWord(string keyword, bool track);

        //Products with specific names
        Product GetPeg();
        Product GetProfile();
        Product GetLine();
        Product GetNail();


        /*  IQueryable<Product> FindProductByPrice(decimal price, bool trackChanges);
          IQueryable<Product> FindProductByPriceRange(decimal price, bool trackChanges);*/
    }
}
