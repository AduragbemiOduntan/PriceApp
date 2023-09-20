using Microsoft.EntityFrameworkCore;
using PriceApp_Domain.Entities;
using PriceApp_Infrastructure.Persistence.ApplicationDbContext;
using PriceApp_Infrastructure.Repositories.Interfaces;
using PriceApp_Shared.RequestFeatures;

namespace PriceApp_Infrastructure.Repositories.Implementations
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly DataBaseContext _context;
        public ProductRepository(DataBaseContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Product> FindProductById(int id)
        {
            return await FindByCondition(x => x.Id == id, false).FirstOrDefaultAsync();
        }

        public async Task<Product> FindProductByName(string productName)
        {
            return await FindByCondition(x => x.ProductName == productName, false)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> FindProductByKeyWord(string keyword)
        {
            return await FindAll(false)
                .Where(x => x.ProductName.Contains(keyword) || x.Description.Contains(keyword) || x.UnitOfMeasurement.Contains(keyword))
                .OrderBy(x => x.ProductName).ToListAsync();
        }

        public async Task<PagedList<Product>> FindAllProduct(ProductParameters productParameter)
        {
            var products = await FindAll(false)
                .OrderBy(x => x.Id)
                .ToListAsync();

            return PagedList<Product>.ToPagedList(products, productParameter.PageNumber, productParameter.PageSize);
        }

        public async Task<IEnumerable<Product>> FindProductByState(string productName, string state)
        {
            return await FindByCondition(x => x.ProductName == productName && x.State == state, false)
                .OrderByDescending(x => x.UnitPrice).ToListAsync();
        }
    }
}
