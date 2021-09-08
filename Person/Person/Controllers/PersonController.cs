using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Person.Domain;
using Person.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private Context _ctx;
        private PersonRepository _personRepository;
        //private readonly ILogger<SomeData> _logger;

        public PersonController(Context ctx)
        {
            _ctx = ctx;
            _personRepository = new PersonRepository(ctx);
        }

        //api/person
        [HttpGet]
        public async Task<ActionResult<List<PersonInfoDTO>>> GetAsync()
        {
            List<PersonInfo> personInfos = await _personRepository.GetAllAsync();
            return Converter.ToDTO(personInfos);
        }

        //api/person/3456
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonInfoDTO>> GetOnIDAsync(Guid id)
        {
            PersonInfo personInfo = await _personRepository.GetOnIDAsync(id);
            return Converter.ToDTO(personInfo);
        }

        // PUT: api/person/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(Guid id, PersonInfoDTO personInfo)
        {
            if (id != personInfo.Id)
            {
                return BadRequest();
            }

            bool ok = await _personRepository.PutAsync(Converter.FromDTO(personInfo));
            return ok ? Ok() : NotFound();
        }

        //api/person
        [HttpPost]
        public async Task<ActionResult> PostAsync(PersonInfoDTO personInfo)
        {
            await _personRepository.PostAsync(Converter.FromDTO(personInfo));

            return Ok();
        }

        // DELETE: api/person/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            PersonInfo personInfo = await _personRepository.GetOnIDAsync(id);

            if (personInfo == null)
            {
                return NotFound();
            }

            await _personRepository.DeleteAsync(personInfo.Id);

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
