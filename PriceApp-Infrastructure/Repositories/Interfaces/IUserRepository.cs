using PriceApp_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> FindUserById(string id, bool trackChanges);
        Task<User> FindUserByEmail(string email, bool trackChanges);
    }
}
