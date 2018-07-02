using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSolarOMS.Model.DistributorModels
{
    public class DistributorDto
    {
        public Guid Id { get; set; }
        public string CoperateName { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string LGA { get; set; }
        public string ResidentialProvinceAddress { get; set; }
        public string ActiveMobileNumber { get; set; }
        public string ActiveMail { get; set; }
    }
}
