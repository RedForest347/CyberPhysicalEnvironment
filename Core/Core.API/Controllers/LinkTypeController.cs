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
    public class LinkTypeController : ControllerBase
    {
        private Context _ctx;
        private LinkTypeRepository _linkTypeRepository;
        //private readonly ILogger<SomeData> _logger;

        public LinkTypeController(Context ctx)
        {
            _ctx = ctx;
            _linkTypeRepository = new LinkTypeRepository(ctx);
        }

        //api/linktype
        [HttpGet]
        public async Task<ActionResult<List<LinkTypeDTO>>> GetLinkTypesAsync()
        {
            List<LinkType> linkTypes = await _linkTypeRepository.GetAllAsync();
            return Converter.ToDTO(linkTypes);
        }

        //api/linktype/3456
        [HttpGet("{id}")]
        public async Task<LinkTypeDTO> GetLinkTypeOnID(Guid id)
        {
            LinkType linkType = await _linkTypeRepository.GetOnIDAsync(id);
            return Converter.ToDTO(linkType);
        }

        //api/linktype
        [HttpPost]
        public async Task<ActionResult> PostLinkTypeAsync(LinkTypeDTO link)
        {
            await _linkTypeRepository.PostAsync(Converter.FromDTO(link));

            return Ok();
        }
    }
}


/*
 
     {
        "Id": "e0cac80e-1311-498e-ade5-aa944c928a22",
        "Code": 1,
        "Description": "not new",
        "Name": "link2"
    }
 */
