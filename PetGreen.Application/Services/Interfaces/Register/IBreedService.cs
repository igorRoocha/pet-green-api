using PetGreen.Domain.Entities.Register;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetGreen.Application.Services.Interfaces.Register
{
    public interface IBreedService
    {
        Task<HttpStatusCode> Register(Breed breed);
    }
}
