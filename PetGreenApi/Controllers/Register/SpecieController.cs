using System;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PetGreen.Application.Services.Services;
using PetGreen.Application.Services.Services.Register;
using PetGreen.Application.Services.Validators.Register;
using PetGreen.Domain.Entities.Register;
using PetGreen.Repository.Context;
using System.Data.SqlClient;

namespace PetGreenApi.Controllers.Register
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecieController : ControllerBase
    {
        private readonly SpecieService _specieService;
        private readonly BaseService<Specie> _baseService;
        private readonly Db _context;
        private readonly IConfiguration _configuration;

        public SpecieController(Db context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _specieService = new SpecieService(context);
            _baseService = new BaseService<Specie>(context);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Specie specie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return StatusCode((int) await _specieService.Register(specie));
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
                return Ok(await _baseService.Get());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Specie specie)
        {
            try
            {
                _baseService.Put<SpecieValidator>(specie);
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
                var sqlException = ex.InnerException as SqlException;

                if (sqlException != null && sqlException.Number == 547)
                    return StatusCode((int)HttpStatusCode.Conflict);

                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
