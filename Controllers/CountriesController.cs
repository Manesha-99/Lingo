using AutoMapper;
using Lingo.Model.Domain;
using Lingo.Model.Dto;
using Lingo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Lingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository countryRepository;
        private readonly IMapper mapper;

        public CountriesController(ICountryRepository countryRepository, IMapper mapper)
        {
            this.countryRepository = countryRepository;
            this.mapper = mapper;
        }


        //GetAll-----------------------------------------------------------

        [HttpGet]

        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, 
            [FromQuery] string? sortBy, [FromQuery] bool isAscending=true, [FromQuery] int pageNumber=1, [FromQuery] int pageSize=5) {
            
            var domainCountryModel = await countryRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending, pageNumber, pageSize);

            if (domainCountryModel != null) {

                return Ok(mapper.Map<List<GetCountriesDto>>(domainCountryModel));
            }
            return BadRequest(); 
        
        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var domainCountryModel =await countryRepository.GetByIdAsync(id);

            if (domainCountryModel != null)
            {
                return Ok(mapper.Map<GetCountriesDto>(domainCountryModel));

            }

            return BadRequest();
        }

        //Create------------------------------------------------------------

        [HttpPost]
        
        public async Task<IActionResult> Create([FromBody] AddCountriesDto addCountriesDto)
        {

            var countryDomainModel = mapper.Map<Country>(addCountriesDto);

            countryDomainModel = await countryRepository.CreateAsync(countryDomainModel);

                if (countryDomainModel != null) { 
                    
                    var countryDto = mapper.Map<GetCountriesDto>(countryDomainModel);

                    return CreatedAtAction(nameof(GetById), new { id = countryDto.Id }, countryDto);
                    
                }

            return BadRequest();
        }


        //Update------------------------------------------------------------

        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AddCountriesDto addCountriesDto)
        {
            var countryDomain = mapper.Map<Country>(addCountriesDto);
            countryDomain = await countryRepository.UpdateAsync(id, countryDomain);

            if (countryDomain != null) {
                return NoContent();
            }

            return BadRequest();    
        }

        //Delete------------------------------------------------------------

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var countryModel = await countryRepository.DeleteAsync(id);

            if (countryModel != null) {

                return NoContent();
            }

            return NotFound();
        }
    }
}
