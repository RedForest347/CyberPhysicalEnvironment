using Microsoft.EntityFrameworkCore;
using Business.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Infrastructure
{
    public class BusinessRepository
    {
        private readonly Context _ctx;
        public Context UnitOfWork
        {
            get
            {
                return _ctx;
            }
        }

        public BusinessRepository(Context context)
        {
            _ctx = context;
        }

        public async Task<List<BusinessInfo>> GetAllAsync()
        {
            return await _ctx.BusinessInfos
                .ToListAsync();
        }

        public async Task<BusinessInfo> GetOnIDAsync(Guid id)
        {
            return await _ctx.BusinessInfos
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task PostAsync(BusinessInfo businessInfo)
        {
            _ctx.BusinessInfos.Add(businessInfo);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            BusinessInfo businessInfo = await _ctx.BusinessInfos.FindAsync(id);
            _ctx.Remove(businessInfo);
            await _ctx.SaveChangesAsync();
        }

        public async Task<bool> PutAsync(BusinessInfo businessInfo)
        {
            BusinessInfo existBusiness = await _ctx.BusinessInfos.FindAsync(businessInfo.Id);

            if (existBusiness == null)
                return false;

            _ctx.Entry(existBusiness).CurrentValues.SetValues(businessInfo);

            try
            {
                await _ctx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessExists(businessInfo.Id))
                {
                    return false;
                }
            }
            return true;
        }





        public bool BusinessExists(Guid id)
        {
            return _ctx.BusinessInfos.Any(p => p.Id == id);
        }
    }
}
