using SourceService.Core.Interfaces.Repositories;
using SourceService.Core.Interfaces.Services;
using SourceService.Core.Models;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceService.Core.Services
{
    public class SourceService : ISourceService
    {
        public readonly ISourceRepository _SourceRepository;
        private readonly ILogger<SourceService> _logger;
        public SourceService(ISourceRepository SourceRepository, ILogger<SourceService> logger)
        {
            _SourceRepository = SourceRepository??throw new ArgumentNullException(nameof(SourceRepository));
            _logger = logger??throw new ArgumentNullException(nameof(logger));
        }   
        public async Task<Source> CreateSource(Source Source)
        {
            try
            {
                return await _SourceRepository.CreateSource(Source);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call CreateSources in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<bool> DeleteSource(int id)
        {
            try
            {
                return await _SourceRepository.DeleteSource(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call DeleteSource in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<IEnumerable<Source>> GetAllSources()
        {
            try
            {
                return await _SourceRepository.GetAllSources();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call GetAllSources in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<Source> GetSourceById(int id)
        {
            try
            {
                return await _SourceRepository.GetSourceById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call GetSourceById in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<Object> UpdateSource(int id, Source Source)
        {
            try
            {
                return await _SourceRepository.UpdateSource(id, Source);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call UpdateSource in service class, Error Message = {ex}.");
                throw;
            }
        }
    }
}
