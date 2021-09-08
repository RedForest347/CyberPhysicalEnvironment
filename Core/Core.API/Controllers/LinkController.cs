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
    public class LinkController : ControllerBase
    {
        private Context _ctx;
        private LinkRepository _linkRepository;

        public LinkController(Context ctx)
        {
            _ctx = ctx;
            _linkRepository = new LinkRepository(ctx);
        }

        //api/link
        [HttpGet]
        public async Task<List<LinkDTO>> GetLinkListAsync()
        {
            List<Link> agents = await _linkRepository.GetAllAsync();
            return Converter.ToDTO(agents);
        }

        //api/link/45
        [HttpGet("{id}")]
        public async Task<LinkDTO> GetLinkOnIdAsync(Guid id)
        {
            Link link = await _linkRepository.GetOnIDAsync(id);
            return Converter.ToDTO(link);
        }


        //api/link
        [HttpPost]
        public async Task<ActionResult> PostLinkAsync(LinkDTO link)
        {
            await _linkRepository.PostAsync(Converter.FromDTO(link));
            return Ok();
        }

        // PUT: api/link/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutLinkAsync(Guid id, LinkDTO link)
        {
            if (id != link.Id)
            {
                return BadRequest();
            }

            bool ok = await _linkRepository.PutAsync(Converter.FromDTO(link));
            return ok ? Ok() : NotFound();
        }

        // DELETE: api/link/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLinkAsync(Guid id)
        {
            //код рабочий, функция не предусмотрена
            return BadRequest();



            /**Link linkType = await _linkRepository.GetOnIDAsync(id);

            if (linkType == null)
            {
                return NotFound();
            }

            await _linkRepository.DeleteAsync(linkType.Id);

            return Ok();*/
        }

    }
}

/*
 example of json request:

    {
        "id": "e0cac80e-1311-498e-ade5-aa944c928a11",
        "ActiveLinkFlag": false,
        "Agent1Checked": false,
        "Agent2Checked": false,
        "CheckedTime": "2021-04-29T19:36:27",
        "CloseTime": "2021-04-29T19:36:27",
        "RequestTime": "2021-04-29T19:36:27",
        "Description": "ddd",
        "Status": 1,
        "Agent1Id": "d2620eee-c277-445a-eb69-08d90cbe2978",
        "Agent2Id": "0891b118-d21b-4f5b-d1d8-08d90cbceaa7",
        "LinkType": {
            "Id": "e0cac80e-1311-498e-ade5-aa944c928a22",
            "Code": 1,
            "Description": "not new",
            "Name": "link2"
        }
    }


*/