using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSolarOMS.Model.DistributorModels
{
    public class DistributorForCreationDto
    {
        public string CoperateName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }
        public string LGA { get; set; }
        public string ResidentialProvinceAddress { get; set; }
        public string ActiveMobileNumber { get; set; }
        public string ActiveMail { get; set; }
        public string DateCreated { get; set; }
    }
}
