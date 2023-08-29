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
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly DataBaseContext _context;
        public UserRepository(DataBaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> FindUserById(string id, bool trackChanges)
        {
            return await FindByCondition(x => x.Id == id, trackChanges).FirstOrDefaultAsync();
        }

        public async Task<User> FindUserByEmail(string email, bool trackChanges)
        {
            return await FindByCondition(x => x.Email == email, trackChanges).FirstOrDefaultAsync();
        }
    }
}
