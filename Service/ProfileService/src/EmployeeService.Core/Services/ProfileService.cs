using ProfileService.Core.Interfaces.Repositories;
using ProfileService.Core.Interfaces.Services;
using ProfileService.Core.Models;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileService.Core.Services
{
    public class ProfileService : IProfileService
    {
        public readonly IProfileRepository _profileRepository;
        private readonly ILogger<ProfileService> _logger;
        public ProfileService(IProfileRepository ProfileRepository, ILogger<ProfileService> logger)
        {
            _profileRepository = ProfileRepository??throw new ArgumentNullException(nameof(ProfileRepository));
            _logger = logger??throw new ArgumentNullException(nameof(logger));
        }   
        public async Task<Profile> CreateProfile(Profile profile)
        {
            try
            {
                return await _profileRepository.CreateProfile(profile);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call CreateProfiles in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<bool> DeleteProfile(int id)
        {
            try
            {
                return await _profileRepository.DeleteProfile(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call DeleteProfile in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<IEnumerable<Profile>> GetAllProfiles()
        {
            try
            {
                return await _profileRepository.GetAllProfiles();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call GetAllProfiles in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<Profile> GetProfileById(int id)
        {
            try
            {
                return await _profileRepository.GetProfileById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call GetProfileById in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<Object> UpdateProfile(int id, Profile Profile)
        {
            try
            {
                return await _profileRepository.UpdateProfile(id, Profile);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call UpdateProfile in service class, Error Message = {ex}.");
                throw;
            }
        }
    }
}
