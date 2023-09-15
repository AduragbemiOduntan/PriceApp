using Microsoft.EntityFrameworkCore;
using PriceApp_Infrastructure.Persistence.ApplicationDbContext;
using PriceApp_Infrastructure.Repositories.Implementations;
using PriceApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Infrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;
        private IProductRepository _productRepository;
        private IUserRepository _userRepository;
        private IMaterialEstimateRepository _materialEstimateRepository;
        private ISettingOutStageRepository _settingOutRepository;
        private IExcavationRepository _excavationRepository;

        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
        }

        public IProductRepository Product
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_context);
                return _productRepository;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);
                return _userRepository;
            }
        }

        public IMaterialEstimateRepository MaterialEstimate
        {
            get
            {
                if(_materialEstimateRepository == null)
                    _materialEstimateRepository = new MaterialEstimateRepository(_context);
                return _materialEstimateRepository;
            }
        }

        public ISettingOutStageRepository SettingOut
        {
            get
            {
                if (_settingOutRepository == null)
                    _settingOutRepository = new SettingOutStageRepository(_context);
                return _settingOutRepository;
            }
        }

        public IExcavationRepository Excavation
        {
            get
            {
                if(_excavationRepository == null)
                    _excavationRepository = new ExcavationRepository(_context); 
                return _excavationRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
