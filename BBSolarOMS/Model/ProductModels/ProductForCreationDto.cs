using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSolarOMS.Model.ProductModels
{
    public class ProductForCreationDto
    {
        public string ProductName { get; set; }
        public string BarCode { get; set; }
        public string Manufacturer { get; set; }
        public int stockQuantity { get; set; }
        public decimal Price { get; set; } = 0.00M;
        public DateTimeOffset LastStalkDate { get; set; } = System.DateTimeOffset.Now;
      //  public byte ProductPicture { get; set; }
    }
}
