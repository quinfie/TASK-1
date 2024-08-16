using Category_Task1.Data;
using Category_Task1.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Category_Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var category = await _context.Categories.ToListAsync();
            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category is null)
            {
                return NotFound("Category not found");
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Category>>> UpdateCategory(Category updateCategory)
        {
            var dbCategory = await _context.Categories.FindAsync(updateCategory.Id);
            if (dbCategory is null)
            {
                return NotFound("Category not found");
            }

            dbCategory.Name = updateCategory.Name;
            dbCategory.Description = updateCategory.Description;
            await _context.SaveChangesAsync();
            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Category>>> DeleteCategory(int id)
        {
            var dbCategory = await _context.Categories.FindAsync(id);
            if (dbCategory is null)
            {
                return NotFound("Category not found");
            }

            _context.Categories.Remove(dbCategory);
            await _context.SaveChangesAsync();
            return Ok(await _context.Categories.ToListAsync());
        }
    }
}
