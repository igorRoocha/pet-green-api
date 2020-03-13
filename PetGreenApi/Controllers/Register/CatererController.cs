using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetGreen.Application.Services.Services;
using PetGreen.Application.Services.Services.Register;
using PetGreen.Domain.DTO.Register;
using PetGreen.Domain.Entities.Register;
using PetGreen.Repository.Context;

namespace PetGreenApi.Controllers.Register
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatererController : ControllerBase
    {
        private readonly CatererService _catererService;
        private readonly Db _context;
        private readonly IConfiguration _configuration;

        public CatererController(Db context, IConfiguration configuration)
        {
            _context = context;
            _catererService = new CatererService(context);
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

        [HttpGet("getByClinicID")]
        public async Task<IActionResult> GetByClinicID(Guid clinicID)
        {
            try
            {
                var obj = await _catererService.GetByClinicID(clinicID);
                return new ObjectResult(await _catererService.GetByClinicID(clinicID));
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
