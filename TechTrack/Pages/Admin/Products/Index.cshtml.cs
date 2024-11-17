using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechTrack.Models;
using TechTrack.Services;

namespace TechTrack.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;
        public List<Product> Products { get; set; } = new List<Product>();
        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Products = context.Products.OrderByDescending(p=> p.Id).ToList();
        }
    }
}
