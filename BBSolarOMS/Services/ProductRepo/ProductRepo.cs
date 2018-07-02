using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBSolarOMS.Entities;

namespace BBSolarOMS.Services.ProductRepo
{
    public class ProductRepo : IProductRepo
    {
        private BBSolarOMSContext _context;
        public ProductRepo(BBSolarOMSContext products)
        {
            _context = products;
        }
        public void AddProduct(Products product)
        {
            product.Id = new Guid();
            _context.Products.Add(product);
        }

        public void DeleteProducts(Products product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Products> GetProducts()
        {
            return _context.Products
                .OrderBy(a => a.ProductName)
                .ThenBy(a => a.Manufacturer)
                .ToList();
        }

        public Products GetProduct(Guid id)
        {
            return _context.Products.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Products> GetProductsById(IEnumerable<Guid> id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Products> GetProductsByManufacturer(string manufacturer)
        {
            return _context.Products.Where(a => a.Manufacturer==manufacturer).ToList();
        }

        public bool ProductExists(Guid id)
        {
            return _context.Products.Any(a => a.Id == id);
        }

        public void ProductUpdate(Products products)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
