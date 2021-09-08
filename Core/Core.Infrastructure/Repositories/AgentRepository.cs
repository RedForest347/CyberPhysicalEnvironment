using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public class AgentRepository
    {
        private readonly Context _ctx;
        public Context UnitOfWork
        {
            get => _ctx;
        }

        public AgentRepository(Context context)
        {
            _ctx = context;
        }

        public async Task<List<Agent>> GetAllAgentsAsync()
        {
            return await _ctx.Agents
                .Include(a => a.AgentType)
                .Include(a => a.InputLinks)
                .Include(a => a.OutputLinks)
                .OrderBy(a => a.Name)
                .ToListAsync();
        }

        public async Task<Agent> GetAgentOnIDAsync(Guid id)
        {
            return await _ctx.Agents
                .Include(a => a.AgentType)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task PostAsync(Agent agent)
        {
            AgentType agentType = _ctx.AgentTypes
                .Where(i => i.Code == agent.AgentType.Code)
                .FirstOrDefault();
            agentType.Agents.Add(agent);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAgentAsync(Guid id)
        {
            Agent agent = await _ctx.Agents.FindAsync(id);
            _ctx.Remove(agent);
            await _ctx.SaveChangesAsync();
        }

        public async Task<bool> PutAsync(Agent agent)
        {
            Agent existAgent = await _ctx.Agents.FindAsync(agent.Id);

            if (existAgent == null)
                return false;

            _ctx.Entry(existAgent).CurrentValues.SetValues(agent);

            try
            {
                await _ctx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgentExists(agent.Id))
                {
                    return false;
                }
            }
            return true;
        }

        public bool AgentExists(Guid id)
        {
            return _ctx.Agents.Any(e => e.Id == id);
        }
    }
}
