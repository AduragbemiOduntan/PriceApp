using Microsoft.EntityFrameworkCore;
using PriceApp_Domain.Entities;
using PriceApp_Infrastructure.Persistence.ApplicationDbContext;
using PriceApp_Infrastructure.Repositories.Interfaces;

namespace PriceApp_Infrastructure.Repositories.Implementations
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly DataBaseContext _context;
        public ProductRepository(DataBaseContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Product> FindProductById(int id, bool trackChanges)
        {
            return await FindByCondition(x => x.Id == id, trackChanges).FirstOrDefaultAsync();
        }

        public async Task<Product> FindProductByName(string productName, bool trackChanges)
        {
            return await FindByCondition(x => x.ProductName == productName, trackChanges).FirstOrDefaultAsync();
        }

        public async  Task<IEnumerable<Product>> FindProductByKeyWord(string keyword, bool track)
        {
            return await FindAll(track)
                .Where(x => x.ProductName.Contains(keyword) || x.Description.Contains(keyword) || x.UnitOfMeasurement.Contains(keyword)).OrderBy(x=>x.ProductName)
                .ToListAsync();

           /* return _context.Set<Product>().Where(x =>
                (x.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase))).OrderBy(x => x.ProductName);*/

   /*         return FindAll(track).Where(x =>
                (x.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase))).OrderBy(x => x.ProductName);*/
        }

        //Products with specific names

        public Product GetPeg()
        {
            const string materialName = "Peg";
            var material = _context.Products.Where(x => x.ProductName == materialName).FirstOrDefault();
            return material;
        }

        public Product GetProfile()
        {
            const string materialName = "Profile";
            var material = _context.Products.Where(x => x.ProductName == materialName).FirstOrDefault();
            return material;
        }

        public Product GetLine()
        {
            const string materialName = "Line";
            var material = _context.Products.Where(x => x.ProductName == materialName).FirstOrDefault();
            return material;
        }

        public Product GetNail()
        {
            const string materialName = "Nail";
            var material = _context.Products.Where(x => x.ProductName == materialName).FirstOrDefault();
            return material;
        }

    }
}
