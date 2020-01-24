using System.ComponentModel.DataAnnotations.Schema;
using PetGreen.Domain.Entities;
using PetGreen.Entities.Interfaces;

namespace PetGreen.Domain.Entities
{
    [Table("CDMidiaSocial")]
    public class MidiaSocial : BaseEntity, IMidiaSocial
    {
        public string URL { get; private set; }

        public Clinic Clinic { get; private set; }

        public void Update(string url) => URL = url; 
    }
}