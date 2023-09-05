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
    public class EscavationRepository : RepositoryBase<Escavation>, IEscavationRepository
    {
        private readonly DataBaseContext _context;
        public EscavationRepository(DataBaseContext context) : base(context)
        {
            _context = context;
        }


    }
}
