using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business.Domain;
using Business.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessController : ControllerBase
    {
        private Context _ctx;
        private BusinessRepository _businessRepository;
        //private readonly ILogger<SomeData> _logger;

        public BusinessController(Context ctx)
        {
            _ctx = ctx;
            _businessRepository = new BusinessRepository(ctx);
        }

        //api/business
        [HttpGet]
        public async Task<ActionResult<List<BusinessInfoDTO>>> GetAsync()
        {
            List<BusinessInfo> businessInfos = await _businessRepository.GetAllAsync();
            return Converter.ToDTO(businessInfos);
        }

        //api/business/3456
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessInfoDTO>> GetOnIDAsync(Guid id)
        {
            BusinessInfo businessInfo = await _businessRepository.GetOnIDAsync(id);
            return Converter.ToDTO(businessInfo);
        }

        // PUT: api/business/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(Guid id, BusinessInfoDTO businessInfo)
        {
            if (id != businessInfo.Id)
            {
                return BadRequest();
            }

            bool ok = await _businessRepository.PutAsync(Converter.FromDTO(businessInfo));
            return ok ? Ok() : NotFound();
        }

        //api/business
        [HttpPost]
        public async Task<ActionResult> PostAsync(BusinessInfoDTO businessInfo)
        {
            await _businessRepository.PostAsync(Converter.FromDTO(businessInfo));

            return Ok();
        }

        // DELETE: api/business/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            BusinessInfo businessInfo = await _businessRepository.GetOnIDAsync(id);

            if (businessInfo == null)
            {
                return NotFound();
            }

            await _businessRepository.DeleteAsync(businessInfo.Id);

            return Ok();
        }
    }
}

/*
 example of json request:
    {
        "Id": "54ca606a-331e-4f61-a650-3e3a0c7cf43a",
        "Name": "Bus",
        "Status": 1,
        "CreateTime": "2015-07-20T18:30:25",
        "Director": "no"
    }


 */
