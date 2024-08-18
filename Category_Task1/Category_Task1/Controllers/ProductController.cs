using Category_Task1.Data;
using Category_Task1.Entities;
using Category_Task1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<ActionResult> GetAllProducts()
        {
            var lsProduct = await _context.Products.ToListAsync();
            return Ok(lsProduct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdProduct(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.ProductId == id);
            if (product != null)
            {
                return Ok(product);
            }
            return BadRequest("Sản phẩm không tồn tại!");
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductModel productModel)
        {
            try
            {
                var existingProduct = await _context.Products
                    .SingleOrDefaultAsync(p => p.ProductName == productModel.ProductName);

                if (existingProduct != null)
                {
                    return BadRequest("Đã tồn tại sản phẩm có cùng tên!");
                }

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

                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, ProductModel productModel)
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return BadRequest("Sản phẩm không tồn tại!");
            }

            var existingProduct = await _context.Products
                .Where(p => p.ProductName == productModel.ProductName && p.ProductId != id)
                .SingleOrDefaultAsync();

            if (existingProduct != null)
            {
                return BadRequest("Đã tồn tại sản phẩm có cùng tên!");
            }

            product.ProductName = productModel.ProductName;
            product.ProductSize = productModel.ProductSize;
            product.ProductPrice = productModel.ProductPrice;
            product.ProductQuantity = productModel.ProductQuantity;
            product.ProductColor = productModel.ProductColor;
            product.ProductImage = productModel.ProductImage;
            product.ProductDescription = productModel.ProductDescription;
            product.Id = productModel.Id;

            await _context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.ProductId == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return Ok("Xóa sản phẩm thành công!");
            }
            return BadRequest("Sản phẩm không tồn tại!");
        }
    }
}