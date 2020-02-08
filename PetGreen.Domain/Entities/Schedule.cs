using System;
using System.ComponentModel.DataAnnotations.Schema;
using PetGreen.Domain.Entities;
using PetGreen.Entities.Interfaces;

namespace PetGreen.Domain.Entities
{
    [Table("CDSchedule")]
    public class Schedule : BaseEntity, ISchedules
    {
        public Schedule()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public string Days { get; set; }

        public string StartHour { get; set; }

        public string EndHour { get; set; }
        public Guid ClinicID { get; set; }

        public virtual Clinic Clinic { get; set; }

        public void Update(Clinic clinic) => Clinic = clinic; 
    }
}