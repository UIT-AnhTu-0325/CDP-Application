using SourceService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceService.Core.Interfaces.Services
{
    public interface ISourceService
    {
        public Task<IEnumerable<Source>> GetAllSources();
        public Task<Source> GetSourceById(int id);
        public Task<Source> CreateSource(Source Source);
        public Task<bool> DeleteSource(int id);
        public Task<Object> UpdateSource(int id, Source Source);
    }
}
