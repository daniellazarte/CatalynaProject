using Catalyna.Core.Entities;
using Catalyna.Core.Interfaces;
using Catalyna.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyna.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CatalynaMediaContext _context;
        public UserRepository(CatalynaMediaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.User.ToListAsync();
            return users;

        }

        public async Task<User> GetUser(int UserId)
        {
            var category = await _context.User.FirstOrDefaultAsync(x => x.idUser == UserId);
            return category;
        }
    }
}
