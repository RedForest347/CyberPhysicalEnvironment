using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public class AgentTypeRepository
    {

        private readonly Context _ctx;
        public Context UnitOfWork
        {
            get => _ctx;
        }

        public AgentTypeRepository(Context context)
        {
            _ctx = context;
        }

        public async Task<List<AgentType>> GetAllAgentTypesAsync()
        {
            return await _ctx.AgentTypes                
                .OrderBy(a => a.Code)
                .ToListAsync();
        }

        public async Task<AgentType> GetAgentTypeOnIDAsync(Guid id)
        {
            return await _ctx.AgentTypes
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }




    }
}
