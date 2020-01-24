using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetGreen.Application.Services;
using PetGreen.Domain.Entities;
using PetGreen.Repository.Context;

namespace PetGreen.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly BaseService<Profile> _service;
        private readonly Db _context;

        public ProfileController(Db context)
        {
            _context = context;
            _service = new BaseService<Profile>(context);
        }
    }
}