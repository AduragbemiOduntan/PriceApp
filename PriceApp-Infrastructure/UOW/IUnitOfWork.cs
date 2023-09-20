using PriceApp_Infrastructure.Repositories.Interfaces;

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
