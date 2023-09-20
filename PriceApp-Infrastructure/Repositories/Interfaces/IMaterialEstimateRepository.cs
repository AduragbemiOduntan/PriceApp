using PriceApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Infrastructure.Repositories.Interfaces
{
    public interface IMaterialEstimateRepository : IRepositoryBase<MaterialEstimate>
    {
        Task<MaterialEstimate> FindMaterialEstimateByAppelationAndStage(string appellation, string stage);
    }
}
