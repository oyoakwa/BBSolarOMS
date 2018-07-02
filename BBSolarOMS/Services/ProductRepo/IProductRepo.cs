using BBSolarOMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSolarOMS.Services.ProductRepo
{
    public interface IProductRepo
    {
        IEnumerable<Products> GetProducts();
        Products GetProduct(Guid id);
        IEnumerable<Products> GetProductsById(IEnumerable<Guid> id);
        IEnumerable<Products> GetProductsByManufacturer(string Manufacturer);
        void AddProduct(Products product);
        void ProductUpdate(Products products);
        bool ProductExists(Guid id);
        void DeleteProducts(Products product);
        bool Save();
    }
}
