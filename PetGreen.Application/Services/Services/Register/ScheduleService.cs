using PetGreen.Application.Services.Interfaces.Register;
using PetGreen.Application.Validators;
using PetGreen.Domain.DTO;
using PetGreen.Domain.Entities;
using PetGreen.Repository.Context;
using PetGreen.Repository.Repositories.Register;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetGreen.Application.Services.Services.Register
{
    public class ScheduleService: IScheduleService
    {
        private readonly BaseService<Schedule> _baseService;
        private readonly ScheduleRepository _scheduleRepository;
        private readonly Db _context;

        public ScheduleService(Db context)
        {
            _context = context;
            _scheduleRepository = new ScheduleRepository(context);
            _baseService = new BaseService<Schedule>(context);
        }

        /// <summary>
        /// Método responsável por atualizar os horários que se referem a empresa que está sendo atualizada
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task Edit(ClinicDto dto)
        {
            try
            {
                List<Schedule> schedules = await _scheduleRepository.GetByClinicID(dto.ID);

                foreach (Schedule s in schedules)
                    await _baseService.Remove(s.ID);

                foreach (Schedule schedule in dto.Schedules)
                {
                    
                    schedule.ClinicID = dto.ID;
                    _baseService.Post<ScheduleValidator>(schedule);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
