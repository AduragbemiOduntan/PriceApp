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
        //Material Estimate for specific products
        /*Task<MaterialEstimate> PegME(double buidingSetbackPermeter, string stage);*/


        // General
        /* Task<MaterialEstimate> GetMaterialEstimateById(int id);
         Task<MaterialEstimate> GetEstimateByUniqueProjectIdAndStage(int uniqueProjectId, string stage);
         Task<MaterialEstimate> GetMaterialEstimateByUniqueProjectId(int uniqueProjectId);
 */
    }
}
