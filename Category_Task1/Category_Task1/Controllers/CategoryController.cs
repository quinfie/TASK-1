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
        // initializes a DataContext object in the CategoryController class
        // to be used in interacting with the database.
        private readonly DataContext _dbcontext;

        public CategoryController(DataContext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            // Get a list of categories from a database using a DbContext object
            var category = await _dbcontext.Categories.ToListAsync();
            return Ok(category);
        }

        //marking the GetCategory(int id) method is a method that handles HTTP GET requests with a dynamic parameter (id).
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            //This code snippet searches for Category objects in the database based on the ID (id).
            var category = await _dbcontext.Categories.FindAsync(id);
            if (category?.Id == null)
            {
                //If the category does not exist (invalid ID),
                //the method returns a 404 error code ("Category not found").
                return NotFound("Category not found");
            }
            //If the catalogue exists, the method of returning information about the catalogue.
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> AddCategory(Category category)
        {
            // Check if a category with the same name already exists
            var existingCategory = await _dbcontext.Categories.FirstOrDefaultAsync(c => c.Name == category.Name);
            if (existingCategory?.Id != null)
            {
                // Category with the same name already exists, handle accordingly (e.g., return an error message)
                return BadRequest("Category with the same name already exists.");
            }
            //Add the category object to the DbSet Categories.
            _dbcontext.Categories.Add(category);
            //Save the changes to the database.
            await _dbcontext.SaveChangesAsync();
            //returns the catalog list after it has been added.
            return Ok(await _dbcontext.Categories.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Category>>> UpdateCategory(Category updateCategory)
        {
            //Search for categories in an ID-based database
            var dbCategory = await _dbcontext.Categories.FindAsync(updateCategory.Id);
            if (dbCategory?.Id == null)
            {
                //If the category with the corresponding ID is not found,
                //the method returns a 404 error code ("Category not found").
                return NotFound("Category not found");
            }
            // Check if a category with the same name already exists (excluding the current category)
            var existingCategory = await _dbcontext.Categories
                .FirstOrDefaultAsync(c => c.Name == updateCategory.Name && c.Id != updateCategory.Id);
            if (existingCategory?.Id != null)
            {
                // Handle the case where a category with the same name already exists.
                // You can return an error message or take appropriate action.
                return BadRequest("Category name already exists.");
            }

            // Update the information of a category in the database.
            dbCategory.Name = updateCategory.Name;
            dbCategory.Description = updateCategory.Description;
            //Save the changes to the database.
            await _dbcontext.SaveChangesAsync();
            //returns the catalog list after it has been updated.
            return Ok(await _dbcontext.Categories.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Category>>> DeleteCategory(int id)
        {
            //search the category in the database based on the ID (id).
            var dbCategory = await _dbcontext.Categories.FindAsync(id);
            if (dbCategory?.Id == null)  //(dbCategory is null)
            {
                //If the category with the corresponding ID is not found,
                //the method returns a 404 error code ("Category not found").
                return NotFound("Category not found");
            }
            //If a catalog is found, it will be removed from the database using _dbcontext. Categories.Remove(dbCategory).
            _dbcontext.Categories.Remove(dbCategory);
            //After deletion, the changes will be saved to the database using await _dbcontext. SaveChangesAsync().
            await _dbcontext.SaveChangesAsync();
            //returns the catalog list after it has been deleted.
            return Ok(await _dbcontext.Categories.ToListAsync());
        }
    }
}
