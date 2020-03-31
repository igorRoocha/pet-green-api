using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PetGreen.Application.Services.Services.Register;
using PetGreen.Domain.DTO.Register;
using PetGreen.Domain.Entities;
using PetGreen.Repository.Context;
using PetGreen.Repository.Repositories.Register;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PetGreenApi.Controllers.Register
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatererController : ControllerBase
    {
        private readonly CatererService _catererService;
        private readonly UserRepository _userRepository;
        private readonly Db _context;
        private readonly IConfiguration _configuration;

        public CatererController(Db context, IConfiguration configuration)
        {
            _context = context;
            _catererService = new CatererService(context);
            _userRepository = new UserRepository(context);
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CatererDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return StatusCode((int)await _catererService.Register(dto));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] CatererDTO dto)
        {
            try
            {
                await _catererService.Edit(dto);
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("getByUserID")]
        public async Task<IActionResult> GetByUserID(Guid userID)
        {
            try
            {
                User user = await  _userRepository.Get(userID);
                return new ObjectResult(await _catererService.GetByClinicID((Guid)user.ClinicID));
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
                await _catererService.Remove(id);
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
