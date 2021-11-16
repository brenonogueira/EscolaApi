using Microsoft.AspNetCore.Mvc;
using School.Core.Entities;
using School.Core.Repositories;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetAllAsync()
        {
            var cities = await cityRepository.GetAllAsync();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetByIdAsync(long id)
        {
            var city = await cityRepository.GetByIdAsync(id);
            if (city == null) return NotFound();
            return Ok(city);
        }

        [HttpPost]
        public async Task<ActionResult<City>> AddAsync(City city)
        {
            if (ModelState.IsValid)
            {
                await cityRepository.AddAsync(city);
                await cityRepository.SaveAsync();
                return CreatedAtAction(nameof(GetByIdAsync), new { Id = city.Id}, city);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(long id, City city)
        {
            if (ModelState.IsValid && id == city.Id)
            {
                if (!(await cityRepository.Exists(id))) 
                    return NotFound();
                cityRepository.Update(city);
                await cityRepository.SaveAsync();
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(long id)
        {
            if (!(await cityRepository.Exists(id)))
                return NotFound();
            await cityRepository.DeleteAsync(id);
            await cityRepository.SaveAsync();
            return NoContent();
        }
    }
}
