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
    public class AgentController : ControllerBase
    {
        private Context _ctx;
        private AgentRepository _agentRepository;

        public AgentController(Context ctx)
        {
            _ctx = ctx;
            _agentRepository = new AgentRepository(ctx);
        }

        //api/agent
        [HttpGet]
        public async Task<ActionResult<List<AgentDTO>>> GetAgentsAsync()
        {
            List<Agent> agents = await _agentRepository
                .GetAllAgentsAsync();

            return Converter.ToDTO(agents);
        }

        //api/agent/3456
        [HttpGet("{id}")]
        public async Task<ActionResult<AgentDTO>> GetAgentOnIDAsync(Guid id)
        {
            Agent agent = await _agentRepository.GetAgentOnIDAsync(id);

            if (agent == null)
                return NoContent();

            return Converter.ToDTO(agent);
        }

        // PUT: api/AgentTypes/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAgentTypeAsync(Guid id, AgentDTO agent)
        {
            if (id != agent.Id)
            {
                return BadRequest();
            }

            bool ok = await _agentRepository.PutAsync(Converter.FromDTO(agent));
            return ok ? Ok() : NotFound();
        }

        //api/agent
        [HttpPost]
        public async Task<ActionResult> PostAgentAsync(AgentDTO agent)
        {
            await _agentRepository.PostAsync(Converter.FromDTO(agent));

            return Ok();
        }

        // DELETE: api/agent/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAgentTypeAsync(Guid id)
        {
            Agent agentType = await _agentRepository.GetAgentOnIDAsync(id);
            
            if (agentType == null)
            {
                return NotFound();
            }

            await _agentRepository.DeleteAgentAsync(agentType.Id);

            return Ok();
        }
    }
}

/*
 example of json request:

    {
        "id": "6f9619ff-8b86-d011-b42d-00cf4fc964f1",
        "descripion": "Agent test",
        "name": "Max",
        "status": 1,
        "registerTime": "2015-07-20T00:00:00",
        "imgURL": "\"\"",
        "objectId": "6f9619ff-8b86-d011-b42d-00cf4fc964fe",
        "agentTypeId": "6f9619ff-8b86-d011-b42d-00cf4fc964ff",
        "agentType": null,
        "inputLinks": [],
        "outputLinks": []
    }

 */
