using AutoMapper;
using AuthenticationService.Core.Interfaces.Repositories;
using AuthenticationService.Core.Models;
using AuthenticationService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EmployeeDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepository(EmployeeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<User> CreateUser(User user)
        {
            var dbEmployee = _mapper.Map<Entities.User>(user);
            await _dbContext.Users.AddAsync(dbEmployee);    
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null)
            {
                return _mapper.Map<User>(user);
            }
            return null;
        }

        public async Task<User> GetUserByUsername(string username)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(i => i.Username == username);
            if (user != null)
            {
                return _mapper.Map<User>(user);
            }
            return null;
        }
    }
}
