using AutoMapper;
using ProfileService.Core.Interfaces.Repositories;
using ProfileService.Core.Models;
using ProfileService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profile = ProfileService.Core.Models.Profile;

namespace ProfileService.Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ProfileDbContext _dbContext;
        private readonly IMapper _mapper;
        public ProfileRepository(ProfileDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<Profile> CreateProfile(Profile Profile)
        {
            var dbProfile = _mapper.Map<Entities.Profile>(Profile);
            await _dbContext.Profiles.AddAsync(dbProfile);
            await _dbContext.SaveChangesAsync();
            return Profile;
        }

        public async Task<bool> DeleteProfile(int id)
        {
            var Profile = await _dbContext.Profiles.FindAsync(id);
            if (Profile != null)
            {
                _dbContext.Profiles.Remove(Profile);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Profile>> GetAllProfiles()
        {
            var Profiles = await _dbContext.Profiles.ToListAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<Profile>>(Profiles);
        }

        public async Task<Profile> GetProfileById(int id)
        {
            var Profile = await _dbContext.Profiles.FindAsync(id);
            if(Profile != null)
            {
                return _mapper.Map<Profile>(Profile);
            }
            return null;
        }

        public async Task<Object> UpdateProfile(int id, Profile Profile)
        {
            var dbProfile = await _dbContext.Profiles.FindAsync(id);
            if (dbProfile == null)
            {
                return new { message = "Not found!" };
            }
            //if (dbProfile.UpdatedAt != Profile.UpdatedAt)
            //{
            //    return new { message = "Profile has been updated, please refresh the page!\n",
            //        update = $"{dbProfile.UpdatedAt}\n",
            //        update2 = $"{Profile.UpdatedAt}\n"
            //    };
            //}
            dbProfile.Name = Profile.Name;
            dbProfile.Address = Profile.Address;
            dbProfile.PhoneNumber = Profile.PhoneNumber;
            dbProfile.Gender = Profile.Gender;
            dbProfile.Email = Profile.Email;
            dbProfile.Dob = Profile.Dob;
            //dbProfile.ImageUrl = Profile.ImageUrl;
            dbProfile.UpdatedAt = DateTime.Now;

            // Update Profile
            _dbContext.Profiles.Update(dbProfile);
            //Commit
            await _dbContext.SaveChangesAsync();
            return new { message = "Update success!", Profile = dbProfile };
        }
    }
}
