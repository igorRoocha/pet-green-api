using PetGreen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetGreen.Application.Services.Interfaces
{
    public interface IAddressService
    {
        void Register(Address address);
    }
}
