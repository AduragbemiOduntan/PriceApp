using PriceApp_Infrastructure.Repositories.Implementations;
using PriceApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Infrastructure.UOW
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        IUserRepository User { get; }
        IMaterialEstimateRepository MaterialEstimate { get; }
        ISettingOutStageRepository SettingOut { get; }
        Task SaveAsync();
    }
}
