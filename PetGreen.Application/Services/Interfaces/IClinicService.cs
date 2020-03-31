using PetGreen.Domain.DTO;
using System.Net;
using System.Threading.Tasks;

namespace PetGreen.Application.Services.Interfaces
{
    public interface IClinicService
    {
        Task<HttpStatusCode> Register(ClinicDto dto);

        Task<HttpStatusCode> Edit(ClinicDto dto);
    }
}
