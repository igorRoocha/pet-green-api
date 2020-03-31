using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using PetGreen.Domain.DTO;
using Newtonsoft.Json;

namespace PetGreen.Domain.Entities
{
    [Table("CDUser")]
    public class User : BaseEntity
    {
        public User()
        {
            CreatedAt = DateTime.UtcNow;
            Active = true;
        }

        public string Email { get; set; }

        public string Name { get; set; }

        public virtual string Password { get; set; }

        [JsonIgnore]
        public byte[] PasswordHash { get; set; }

        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }

        public Guid ProfileID { get; set; }
        public virtual Profile Profile { get; set; }

        public Guid? ClinicID { get; set; }

        [ForeignKey("ClinicID")]
        public virtual Clinic Clinic { get; set; }

        public IReadOnlyCollection<Contact> Contacts { get; set; }

        public bool Active { get; set; }

        public void Update(bool active) => Active = active;

        public void Update(DateTime? updatedAt, DateTime? deletedAt)
        {
            UpdatedAt = updatedAt;
            DeletedAt = deletedAt;
        }

        public void Update(bool active, DateTime? updatedAt, DateTime? deletedAt)
        {
            Active = active;
            UpdatedAt = updatedAt;
            DeletedAt = deletedAt;
        }

        /// <summary>
        /// Convert o objeto UserDTO para a entidade User
        /// </summary>
        /// <param name="user"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public User FillUser(User user, UserDto dto)
        {
            foreach (var property in dto.GetType().GetProperties())
            {
                var prop = user.GetType().GetProperty(property.Name);
                if (prop != null)
                {
                    var value = dto.GetType().GetProperty(property.Name).GetValue(dto);
                    user.GetType().GetProperty(property.Name).SetValue(user, value);
                }
            }

            return user;
        }

        // public Guid GetUserId()
        // {
        //     return new Guid(_http.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
        // }
    }
}