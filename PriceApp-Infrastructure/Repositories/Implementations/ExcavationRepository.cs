using PriceApp_Domain.Entities;
using PriceApp_Infrastructure.Persistence.ApplicationDbContext;
using PriceApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Infrastructure.Repositories.Implementations
{
    public class ExcavationRepository : RepositoryBase<Excavation>, IExcavationRepository
    {
        private readonly DataBaseContext _context;
        public ExcavationRepository(DataBaseContext context) : base(context)
        {
            _context = context;
        }


    }
}
