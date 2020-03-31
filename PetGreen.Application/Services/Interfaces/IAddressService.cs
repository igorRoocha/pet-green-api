using PetGreen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetGreen.Application.Services.Interfaces
{
    public interface IAddressService
    {
        void Register(Address address);

        Task Remove(IReadOnlyCollection<Address> addresses);
    }
}
