using Category_Task1.Data;
using Category_Task1.Entities;
using Category_Task1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Category_Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetAllProducts()
        {
            var lsProduct = _context.Products;
            return Ok(lsProduct);
        }

        [HttpGet("{id}")]
        public ActionResult GetByIdProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductModel productModel)
        {
            try
            {
                var product = new Product
                {
                    ProductName = productModel.ProductName,
                    ProductSize = productModel.ProductSize,
                    ProductPrice = productModel.ProductPrice,
                    ProductQuantity = productModel.ProductQuantity,
                    ProductColor = productModel.ProductColor,
                    ProductDescription = productModel.ProductDescription,
                    ProductImage = productModel.ProductImage,
                    Id = productModel.Id,
                };
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        public ActionResult UpdateProduct(int id, ProductModel productModel)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                product.ProductName = productModel.ProductName;
                product.ProductSize = productModel.ProductSize;
                product.ProductPrice = productModel.ProductPrice;
                product.ProductQuantity = productModel.ProductQuantity; 
                product.ProductColor = productModel.ProductColor;
                product.ProductImage = productModel.ProductImage;
                product.ProductDescription = productModel.ProductDescription;
                product.Id = productModel.Id;
                _context.SaveChanges();
                return Ok(product);
            }
            else
                return NotFound();
        }

        [HttpDelete]
        public ActionResult DeleteProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
