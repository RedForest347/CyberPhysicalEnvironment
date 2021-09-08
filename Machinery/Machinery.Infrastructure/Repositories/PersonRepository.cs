using Microsoft.EntityFrameworkCore;
using Machinery.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machinery.Infrastructure
{
    public class MachineryRepository
    {
        private readonly Context _ctx;
        public Context UnitOfWork
        {
            get
            {
                return _ctx;
            }
        }

        public MachineryRepository(Context context)
        {
            _ctx = context;
        }

        public async Task<List<MachineryInfo>> GetAllAsync()
        {
            return await _ctx.MachineryInfos
                .ToListAsync();
        }

        public async Task<MachineryInfo> GetOnIDAsync(Guid id)
        {
            return await _ctx.MachineryInfos
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task PostAsync(MachineryInfo machineryInfo)
        {
            _ctx.MachineryInfos.Add(machineryInfo);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            MachineryInfo machineryInfo = await _ctx.MachineryInfos.FindAsync(id);
            _ctx.Remove(machineryInfo);
            await _ctx.SaveChangesAsync();
        }

        public async Task<bool> PutAsync(MachineryInfo machineryInfo)
        {
            MachineryInfo existMachinery = await _ctx.MachineryInfos.FindAsync(machineryInfo.Id);

            if (existMachinery == null)
                return false;

            _ctx.Entry(existMachinery).CurrentValues.SetValues(machineryInfo);

            try
            {
                await _ctx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineryExists(machineryInfo.Id))
                {
                    return false;
                }
            }
            return true;
        }





        public bool MachineryExists(Guid id)
        {
            return _ctx.MachineryInfos.Any(p => p.Id == id);
        }
    }
}
