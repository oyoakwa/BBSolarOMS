using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BBSolarOMS.Entities
{
    public class Distributor
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(55)]
        public string CoperateName { get; set; }

        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(25)]
        public string LastName { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string LGA { get; set; }

        [Required]
        public string ResidentialProvinceAddress { get; set; }

        [Required]
        public string  ActiveMobileNumber { get; set; }

        [Required]
        public string ActiveMail { get; set; }

        [Required]
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset LastEditedOn { get; set; }
    }
}
