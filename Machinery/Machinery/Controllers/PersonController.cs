using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Machinery.Domain;
using Machinery.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Machinery
{
    [ApiController]
    [Route("api/[controller]")]
    public class MachineryController : ControllerBase
    {
        private Context _ctx;
        private MachineryRepository _machineryRepository;
        //private readonly ILogger<SomeData> _logger;

        public MachineryController(Context ctx)
        {
            _ctx = ctx;
            _machineryRepository = new MachineryRepository(ctx);
        }

        //api/machinery
        [HttpGet]
        public async Task<ActionResult<List<MachineryInfoDTO>>> GetAsync()
        {
            List<MachineryInfo> machineryInfos = await _machineryRepository.GetAllAsync();
            return Converter.ToDTO(machineryInfos);
        }

        //api/machinery/3456
        [HttpGet("{id}")]
        public async Task<ActionResult<MachineryInfoDTO>> GetOnIDAsync(Guid id)
        {
            MachineryInfo machineryInfo = await _machineryRepository.GetOnIDAsync(id);
            return Converter.ToDTO(machineryInfo);
        }

        // PUT: api/machinery/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(Guid id, MachineryInfoDTO machineryInfo)
        {
            if (id != machineryInfo.Id)
            {
                return BadRequest();
            }

            bool ok = await _machineryRepository.PutAsync(Converter.FromDTO(machineryInfo));
            return ok ? Ok() : NotFound();
        }

        //api/machinery
        [HttpPost]
        public async Task<ActionResult> PostAsync(MachineryInfoDTO machineryInfo)
        {
            await _machineryRepository.PostAsync(Converter.FromDTO(machineryInfo));

            return Ok();
        }

        // DELETE: api/machinery/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            MachineryInfo machineryInfo = await _machineryRepository.GetOnIDAsync(id);

            if (machineryInfo == null)
            {
                return NotFound();
            }

            await _machineryRepository.DeleteAsync(machineryInfo.Id);

            return Ok();
        }
    }
}

/*
 example of json request:
    {
        "Id": "215bebdc-3cf6-4b1f-a9bc-cd44591d7991",
        "Name": "new2",
        "Pasport": "3485734897",
        "INN": "36234",
        "Sex": "M",
        "Mail": "zzz",
        "CreateTime": "2015-07-20T00:00:00",
        "Status": 1
    }


 */
