using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PetGreen.Application.Services.Services.Register;
using PetGreen.Domain.Entities.Register;
using PetGreen.Repository.Context;

namespace PetGreenApi.Controllers.Register
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecieController : ControllerBase
    {
        private readonly SpecieService _specieService;
        private readonly Db _context;
        private readonly IConfiguration _configuration;

        public SpecieController(Db context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _specieService = new SpecieService(context);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Specie specie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return StatusCode((int)_specieService.Register(specie));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
