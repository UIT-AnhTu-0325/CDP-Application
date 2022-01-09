using ProfileService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileService.Core.Interfaces.Services
{
    public interface IProfileService
    {
        public Task<IEnumerable<Profile>> GetAllProfiles();
        public Task<Profile> GetProfileById(int id);
        public Task<Profile> CreateProfile(Profile Profile);
        public Task<bool> DeleteProfile(int id);
        public Task<Object> UpdateProfile(int id, Profile Profile);
    }
}
