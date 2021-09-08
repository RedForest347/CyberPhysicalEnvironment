using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public class LinkTypeRepository
    {
        private readonly Context _ctx;
        public Context UnitOfWork
        {
            get => _ctx;
        }

        public LinkTypeRepository(Context context)
        {
            _ctx = context;
        }

        public async Task<List<LinkType>> GetAllAsync()
        {
            return await _ctx.LinkTypes
                .OrderBy(a => a.Code)
                .ToListAsync();
        }

        public async Task<LinkType> GetOnIDAsync(Guid id)
        {
            return await _ctx.LinkTypes
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task PostAsync(LinkType linkType)
        {
            _ctx.LinkTypes.Add(linkType);
            await _ctx.SaveChangesAsync();
        }
    }
}
