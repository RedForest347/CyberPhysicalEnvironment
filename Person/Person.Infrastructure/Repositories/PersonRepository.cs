using Microsoft.EntityFrameworkCore;
using Person.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Infrastructure
{
    public class PersonRepository
    {
        private readonly Context _ctx;
        public Context UnitOfWork
        {
            get
            {
                return _ctx;
            }
        }

        public PersonRepository(Context context)
        {
            _ctx = context;
        }

        public async Task<List<PersonInfo>> GetAllAsync()
        {
            return await _ctx.PersonInfos
                .ToListAsync();
        }

        public async Task<PersonInfo> GetOnIDAsync(Guid id)
        {
            return await _ctx.PersonInfos
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task PostAsync(PersonInfo personInfo)
        {
            _ctx.PersonInfos.Add(personInfo);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            PersonInfo personInfo = await _ctx.PersonInfos.FindAsync(id);
            _ctx.Remove(personInfo);
            await _ctx.SaveChangesAsync();
        }

        public async Task<bool> PutAsync(PersonInfo personInfo)
        {
            PersonInfo existPerson = await _ctx.PersonInfos.FindAsync(personInfo.Id);

            if (existPerson == null)
                return false;

            _ctx.Entry(existPerson).CurrentValues.SetValues(personInfo);

            try
            {
                await _ctx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(personInfo.Id))
                {
                    return false;
                }
            }
            return true;
        }





        public bool PersonExists(Guid id)
        {
            return _ctx.PersonInfos.Any(p => p.Id == id);
        }
    }
}
