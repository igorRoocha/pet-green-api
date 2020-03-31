using PetGreen.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetGreen.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<HttpStatusCode> Register(UserDto dto);
    }
}
