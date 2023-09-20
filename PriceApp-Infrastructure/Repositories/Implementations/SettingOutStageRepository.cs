using Microsoft.EntityFrameworkCore;
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
    public class SettingOutStageRepository : RepositoryBase<SettingOutStage>, ISettingOutStageRepository
    {
        private readonly DataBaseContext _context;
        public SettingOutStageRepository(DataBaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<SettingOutStage> GetSettingOutByUniqueProjectId(string appellation)
        {
            return await FindByCondition(x => x.Appellation == appellation, false).FirstOrDefaultAsync();
        }


    }
}
