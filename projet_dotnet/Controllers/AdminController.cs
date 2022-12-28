using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projet_dotnet.Data;

namespace projet_dotnet.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
           
        }

        public async Task<IActionResult> IndexAsync()
        {
            ViewBag.Users=await _context.Users.ToListAsync();   
            return View();
        }
    }
}
