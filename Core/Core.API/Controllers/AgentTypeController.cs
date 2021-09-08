using Core.Domain;
using Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentTypeController : ControllerBase
    {
        private Context _ctx;
        private AgentTypeRepository _agentTypeRepository;
        //private readonly ILogger<SomeData> _logger;

        public AgentTypeController(Context ctx)
        {
            _ctx = ctx;
            _agentTypeRepository = new AgentTypeRepository(ctx);
        }

        //api/agenttype
        [HttpGet]
        public async Task<ActionResult<List<AgentTypeDTO>>> GetAgentTypesAsync()
        {
            List<AgentType> agentTypes = await _agentTypeRepository.GetAllAgentTypesAsync();
            return Converter.ToDTO(agentTypes);
        }

        //api/agenttype/3456
        [HttpGet("{id}")]
        public async Task<AgentTypeDTO> GetAgentOnID(Guid id)
        {
            AgentType agentType = await _agentTypeRepository.GetAgentTypeOnIDAsync(id);
            return Converter.ToDTO(agentType);
        }

    }
}
