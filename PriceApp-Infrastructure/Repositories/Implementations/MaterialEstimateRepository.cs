using Microsoft.EntityFrameworkCore;
using PriceApp_Domain.Dtos.Responses;
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
    public class MaterialEstimateRepository : RepositoryBase<MaterialEstimate>, IMaterialEstimateRepository
    {
        private readonly DataBaseContext _context;

        public MaterialEstimateRepository(DataBaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<MaterialEstimate> FindMaterialEstimateByAppelationAndStage(string appellation, string stage)
        {
            return await FindByCondition(x => x.Appellation == appellation && x.Stage == stage, false).FirstOrDefaultAsync();
        }
    }
}
