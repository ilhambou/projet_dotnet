using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projet_dotnet.Data;
using projet_dotnet.Models;
using System.Text.Json;



namespace projet_dotnet.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
       
        public CartController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            
        }
        [Authorize]
        public IActionResult Index()
        {
            List<CartItem> cart =  new List<CartItem>();

            CartViewModel cartVM = new()
            {
                CartItems = cart,
                GrandTotal = (decimal)cart.Sum(x => x.Quantity * x.Price)
            };

            return View(cartVM);
        }

        public async Task<IActionResult> Add(int id)
                {
                        Product product = await _context.Products.FindAsync(id);

                        List<CartItem> cart =  new List<CartItem>();

                        CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

                        if (cartItem == null)
                        {
                                cart.Add(new CartItem(product));
                        }
                        else
                        {
                                cartItem.Quantity += 1;
                        }


                          TempData["Success"] = "The product has been added!";

                        return Redirect(Request.Headers["Referer"].ToString());
                }
    }
}
