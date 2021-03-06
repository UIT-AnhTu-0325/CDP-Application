using AuthenticationService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public Task<User> CreateUser (User user);
        public Task<User> GetUserByUsername (string username);
        public Task<User> GetUserById (int id);
    }
}
