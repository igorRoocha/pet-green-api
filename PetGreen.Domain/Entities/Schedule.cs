using System;
using System.ComponentModel.DataAnnotations.Schema;
using PetGreen.Domain.Entities;
using PetGreen.Entities.Interfaces;

namespace PetGreen.Domain.Entities
{
    [Table("CDSchedule")]
    public class Schedule : BaseEntity, ISchedules
    {
        public Schedule(string day, string startHour, string endHour)
        {
            Day = day;
            StartHour = startHour;
            EndHour = endHour;
        }

        public string Day { get; private set; }

        public string StartHour { get; private set; }

        public string EndHour { get; private set; }

        public Clinic Clinic { get; private set; }
    }
}