using AutoMapper;
using SourceService.Core.Interfaces.Repositories;
using SourceService.Core.Models;
using SourceService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Source = SourceService.Core.Models.Source;

namespace SourceService.Infrastructure.Repositories
{
    public class SourceRepository : ISourceRepository
    {
        private readonly SourceDbContext _dbContext;
        private readonly IMapper _mapper;
        public SourceRepository(SourceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<Source> CreateSource(Source Source)
        {
            var dbSource = _mapper.Map<Entities.Source>(Source);
            await _dbContext.Sources.AddAsync(dbSource);
            await _dbContext.SaveChangesAsync();
            return Source;
        }

        public async Task<bool> DeleteSource(int id)
        {
            var Source = await _dbContext.Sources.FindAsync(id);
            if (Source != null)
            {
                _dbContext.Sources.Remove(Source);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Source>> GetAllSources()
        {
            var Sources = await _dbContext.Sources.ToListAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<Source>>(Sources);
        }

        public async Task<Source> GetSourceById(int id)
        {
            var Source = await _dbContext.Sources.FindAsync(id);
            if(Source != null)
            {
                return _mapper.Map<Source>(Source);
            }
            return null;
        }

        public async Task<Object> UpdateSource(int id, Source Source)
        {
            var dbSource = await _dbContext.Sources.FindAsync(id);
            if (dbSource == null)
            {
                return new { message = "Not found!" };
            }
            //if (dbSource.UpdatedAt != Source.UpdatedAt)
            //{
            //    return new { message = "Source has been updated, please refresh the page!\n",
            //        update = $"{dbSource.UpdatedAt}\n",
            //        update2 = $"{Source.UpdatedAt}\n"
            //    };
            //}
            dbSource.Name = Source.Name;
            dbSource.Link = Source.Link;
            dbSource.CreateAt = Source.CreateAt;
            dbSource.UpdateAt = Source.UpdateAt;
            dbSource.IsActive = Source.IsActive;

            // Update Source
            _dbContext.Sources.Update(dbSource);
            //Commit
            await _dbContext.SaveChangesAsync();
            return new { message = "Update success!", Source = dbSource };
        }
    }
}
