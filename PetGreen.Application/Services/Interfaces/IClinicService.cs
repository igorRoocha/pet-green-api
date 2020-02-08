using PetGreen.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PetGreen.Application.Services.Interfaces
{
    public interface IClinicService
    {
        HttpStatusCode Register(ClinicDto dto);
    }
}
