using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Data;
using Task1.Models;

namespace Task1.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("You have accessed the Admin controller.");
        }
    }
}
