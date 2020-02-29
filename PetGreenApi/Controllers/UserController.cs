using System.Net;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using PetGreen.Domain.Entities;
using PetGreen.Repository.Context;
using PetGreen.Domain.Models;
using PetGreen.Domain.DTO;
using PetGreen.Application.Services.Services;

namespace PetGreenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly BaseService<User> _baseService;
        private readonly Db _context;
        private readonly IConfiguration _configuration;

        public UserController(Db context, IConfiguration configuration)
        {
            _context = context;
            _userService = new UserService(context);
            _baseService = new BaseService<User>(context);
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User login)
        {
            try
            {
                var user = await (from r in _context.User where r.Email == login.Email select r).Include(x => x.Profile).FirstOrDefaultAsync();

                if (user == null)
                    return NotFound();

                if (!Cryptography.VerifyPassword(password: login.Password, PasswordHash: user.PasswordHash,
                                                 PasswordSalt: user.PasswordSalt) || !user.Active)
                    return Unauthorized();

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);
                var subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()), new Claim(ClaimTypes.Name, user.Email) });
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = subject,
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                         SecurityAlgorithms.HmacSha512Signature, SecurityAlgorithms.Sha512Digest)
                };

                var tokenGeneretade = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new UserDto
                {
                    ID = user.ID,
                    Token = tokenHandler.WriteToken(tokenGeneretade),
                    Email = user.Email,
                    Name = user.Name,
                    ClinicID = user.ClinicID != Guid.Empty ? (Guid)user.ClinicID : Guid.Empty,
                    Profile = user.Profile
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _userService.Register(dto);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            try
            {
                //_userService.Put<UserValidator>(user);
                return new ObjectResult(user);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            try
            {
                //await _userService.Remove(id);
                return new NoContentResult();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
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
                return new ObjectResult(await _baseService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                User user = await _context.User.Where(x => x.ID == id)
                                    .Include(x => x.Profile).Include(x => x.Clinic).FirstOrDefaultAsync();
                return new ObjectResult(user);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}