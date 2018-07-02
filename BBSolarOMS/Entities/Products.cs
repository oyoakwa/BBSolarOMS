using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BBSolarOMS.Entities
{
    
    public class Products
    {
        public Guid Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string BarCode { get; set; }
        [Display(Name ="Manufactured By")]
        public string Manufacturer { get; set; }
        [Required]
        public int stockQuantity { get; set; }
        public decimal Price { get; set; } = 0.00M;
        public DateTimeOffset LastStalkDate { get; set; } = System.DateTimeOffset.Now;
        public byte ProductPicture { get; set; }
    }
}
