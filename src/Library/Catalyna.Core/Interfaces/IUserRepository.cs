using Catalyna.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyna.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int UserId);
        Task<IEnumerable<User>> GetUsers();
    }
}