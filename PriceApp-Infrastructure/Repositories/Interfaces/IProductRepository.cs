using PriceApp_Domain.Entities;
using PriceApp_Shared.RequestFeatures;

namespace PriceApp_Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<Product> FindProductById(int id);
        Task<Product> FindProductByName(string productName);
        Task<IEnumerable<Product>> FindProductByKeyWord(string keyword);
        Task<PagedList<Product>> FindAllProduct(ProductParameters productParameter);
        Task<IEnumerable<Product>> FindProductByState(string productName, string state);
    }
}
