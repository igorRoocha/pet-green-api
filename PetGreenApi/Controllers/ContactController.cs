using Microsoft.AspNetCore.Mvc;
using PetGreen.Application.Services;
using PetGreen.Domain.Entities;
using PetGreen.Repository.Context;

namespace PetGreen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly BaseService<Contact> _service;
        private readonly Db _context;

        public ContactController(Db context)
        {
            _context = context;
            _service = new BaseService<Contact>(context);
        }
    }
}