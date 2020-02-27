using PetGreen.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetGreen.Application.Services.Interfaces
{
    public interface IClinicService
    {
        Task<HttpStatusCode> Register(ClinicDto dto);
    }
}
