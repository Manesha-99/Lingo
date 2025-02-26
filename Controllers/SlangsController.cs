using AutoMapper;
using Lingo.Model.Domain;
using Lingo.Model.Dto;
using Lingo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace Lingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlangsController : ControllerBase
    {
        private readonly ISlangsRepository slangsRepository;
        private readonly IMapper mapper;

        public SlangsController(ISlangsRepository slangsRepository, IMapper mapper)
        {
            this.slangsRepository = slangsRepository;
            this.mapper = mapper;
        }

        //Function for get all slangs------------------------------------------
        [HttpGet]

        public async Task<IActionResult> GetAll([FromQuery] string? filterOn=null, [FromQuery] string? filterQuery=null,
            [FromQuery] string? sortBy = null, [FromQuery] bool isAscending=true, [FromQuery] int pageNumber=1, [FromQuery] int pageSize=100)
        {
            var walkdomainModel = await slangsRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending, pageNumber, pageSize);

            if (walkdomainModel != null) {

                var dtoModel = mapper.Map<List<GetSlangsDto>>(walkdomainModel);

                return Ok(dtoModel);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var slangDomainModel = await slangsRepository.GeyByIdAsync(id);

            if (slangDomainModel != null) {
                
                return Ok(mapper.Map<GetSlangsDto>(slangDomainModel));
            }

            return NotFound();
        }

        //Function to Create a slang----------------------------------

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddSlangRequestDto addSlangRequestDto)
        {
            var slangDomainModel = mapper.Map<Slang>(addSlangRequestDto);

            slangDomainModel = await slangsRepository.CreateAsync(slangDomainModel);

            if(slangDomainModel != null)
            {
                var slangDto = mapper.Map<GetSlangsDto>(slangDomainModel);
                return CreatedAtAction(nameof(GetById), new {id = slangDto.Id}, slangDto);
            }

            return BadRequest();
        }


        //Function to Update slang by ID

        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> UpdateById([FromRoute] Guid id, [FromBody] AddSlangRequestDto addSlangRequestDto)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var domainSlangModel = mapper.Map<Slang>(addSlangRequestDto);

            domainSlangModel = await slangsRepository.UpdateAsync(id, domainSlangModel);

            if (domainSlangModel != null)
            {
                var slangDto = mapper.Map<GetSlangsDto>(domainSlangModel);
                return Ok(slangDto);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DeleteByID([FromRoute] Guid id)
        {
            var domainModel = await slangsRepository.DeleteAsync(id);

            if (domainModel != null)
            {
                return NoContent();
            }

            return NotFound();

        }

    }
}
