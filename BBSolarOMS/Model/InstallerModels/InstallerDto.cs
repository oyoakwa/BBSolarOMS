using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSolarOMS.Model.InstallerModels
{
    public class InstallerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string State { get; set; }
        public string LGA { get; set; }
    }
}
