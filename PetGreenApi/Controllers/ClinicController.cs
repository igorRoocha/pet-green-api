using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PetGreen.Application.Services;
using PetGreen.Domain.DTO;
using PetGreen.Domain.Entities;
using PetGreen.Repository.Context;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PetGreenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly BaseService<Clinic> _clinicService;
        private readonly BaseService<Contact> _contactService;
        private readonly Db _context;
        private readonly IConfiguration _configuration;

        public ClinicController(Db context, IConfiguration configuration)
        {
            _context = context;
            _clinicService = new BaseService<Clinic>(context);
            _contactService = new BaseService<Contact>(context);
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] ClinicDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("GetClinic")]
        public async Task GetClinic()
        {
        }
    }
}
