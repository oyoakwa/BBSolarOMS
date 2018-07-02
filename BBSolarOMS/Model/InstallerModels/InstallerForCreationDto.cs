using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSolarOMS.Model.InstallerModels
{
    public class InstallerForCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTimeOffset DOB { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public string State { get; set; }
        public string LGA { get; set; }
    }
}
