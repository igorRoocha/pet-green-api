using PetGreen.Domain.DTO;
using System.Threading.Tasks;

namespace PetGreen.Application.Services.Interfaces.Register
{
    public interface IScheduleService
    {
        Task Edit(ClinicDto dto);
    }
}
