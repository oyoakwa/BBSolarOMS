using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BBSolarOMS.Entities
{
    public class Installers
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }

        public string Gender { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTimeOffset DOB { get; set; }

        [Required]
        public string Address { get; set; }

        public string Email { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        public string State { get; set; }

        public string LGA { get; set; }

        [Required]
        public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset LastEditedOn { get; set; }
    }
}
