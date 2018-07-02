using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BBSolarOMS.Entities;
using BBSolarOMS.Model.ProductModels;
using BBSolarOMS.Services.ProductRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BBSolarOMS.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private IProductRepo _product;
        public ProductsController(IProductRepo product)
        {
            _product = product;
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody]ProductForCreationDto product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var productForEntity = Mapper.Map<Products>(product);
            _product.AddProduct(productForEntity);
            if (!_product.Save())
            {
                throw new Exception($"Product Creation failed on save");
            }

            var productToReturn = Mapper.Map<Products>(productForEntity);
            return CreatedAtRoute("GetProduct", new { id = productToReturn.Id }, productToReturn);
        }

        [HttpGet("{id}",Name ="GetProduct")]
        public IActionResult GetProduct(Guid prodId)
        {
            var productFromRepo = _product.GetProduct(prodId);
            if(productFromRepo==null)
            {
                return NotFound();
            }
            var product = Mapper.Map<ProductDto>(productFromRepo);
            return Ok(product);
        }
    }
}