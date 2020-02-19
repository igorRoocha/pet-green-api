using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PetGreen.Application.Services.Services;
using PetGreen.Application.Services.Services.Register;
using PetGreen.Application.Services.Validators.Register;
using PetGreen.Domain.Entities.Register;
using PetGreen.Repository.Context;

namespace PetGreenApi.Controllers.Register
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreedController : ControllerBase
    {
        private readonly BaseService<Breed> _baseService;
        private readonly BreedService _breedService;
        private readonly Db _context;
        private readonly IConfiguration _configuration;

        public BreedController(Db context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _baseService = new BaseService<Breed>(context);
            _breedService = new BreedService(context);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Breed breed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return StatusCode((int)await _breedService.Register(breed));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return new ObjectResult(await _context.Breed.AsNoTracking().Include("Specie").OrderBy(b => b.Name).ToListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Breed breed)
        {
            try
            {
                _baseService.Put<BreedValidator>(breed);
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await _baseService.Remove(id);
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
