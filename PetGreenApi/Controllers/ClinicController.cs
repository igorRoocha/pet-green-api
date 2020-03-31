using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PetGreen.Application.Services.Services;
using PetGreen.Domain.DTO;
using PetGreen.Domain.Entities;
using PetGreen.Repository.Context;
using PetGreen.Repository.Repositories.Register;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PetGreenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly ClinicService _clinicService;
        private readonly ClinicRepository _clinicRepository;
        private readonly UserRepository _userRepository;
        private readonly Db _context;
        private readonly IConfiguration _configuration;

        public ClinicController(Db context, IConfiguration configuration)
        {
            _context = context;
            _clinicService = new ClinicService(context);
            _clinicRepository = new ClinicRepository(context);
            _userRepository = new UserRepository(context);
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] ClinicDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return StatusCode((int)await _clinicService.Register(dto));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("{userID}")]
        public async Task<IActionResult> GetByUserID(Guid userID)
        {
            try
            {
                Guid clinicID = Guid.Empty;
                User user = await _userRepository.Get(userID);

                if(user.ClinicID != null && user.ClinicID != Guid.Empty)
                    clinicID = (Guid)user.ClinicID;

                return new ObjectResult(await _clinicRepository.Get(clinicID));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] ClinicDto dto)
        {
            try
            {
                await _clinicService.Edit(dto);
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
