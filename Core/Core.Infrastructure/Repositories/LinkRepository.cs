using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public class LinkRepository
    {
        private readonly Context _ctx;
        public Context UnitOfWork
        {
            get => _ctx;
        }
        public LinkRepository(Context context)
        {
            _ctx = context;
        }

        public async Task<List<Link>> GetAllAsync()
        {
            return await _ctx.Links
                .Include(a => a.LinkType)
                .OrderBy(a => a.Description)
                .ToListAsync();
        }

        public async Task<Link> GetOnIDAsync(Guid id)
        {
            return await _ctx.Links
                .Include(a => a.LinkType)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task PostAsync(Link link)
        {
            LinkType linkType = _ctx.LinkTypes.Where(i => i.Code == link.LinkType.Code).FirstOrDefault();

            linkType.Links.Add(link);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Link link = await _ctx.Links.FindAsync(id);
            _ctx.Remove(link);
            await _ctx.SaveChangesAsync();
        }

        public async Task<bool> PutAsync(Link link)
        {
            Link existLink = await _ctx.Links.FindAsync(link.Id);

            if (existLink == null)
            {
                return false;
            }

            _ctx.Entry(existLink).CurrentValues.SetValues(link);

            try
            {
                await _ctx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkExists(link.Id))
                {
                    return false;
                }
            }
            return true;
        }





        private bool LinkExists(Guid id)
        {
            return _ctx.Links.Any(e => e.Id == id);
        }

    }
}
