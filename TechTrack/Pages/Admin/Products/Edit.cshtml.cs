using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechTrack.Models;
using TechTrack.Services;

namespace TechTrack.Pages.Admin.Products
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;

        [BindProperty]
        public ProductDto ProductDto { get; set; } = new ProductDto();
        public Product Product { get; set; } = new Product();
        public string errorMessage = "";
        public string successMessage = "";
        public EditModel(IWebHostEnvironment environment, ApplicationDbContext context) 
        { 
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if (id == null) {
                Response.Redirect("/Admin/Products/Index");
                return;
            }
            var product = context.Products.Find(id);
			if (product == null)
			{
				Response.Redirect("/Admin/Products/Index");
				return;
			}
			ProductDto.Name = "";
			ProductDto.Brand = "";
			ProductDto.Category = "";
			ProductDto.Price = 0;
			ProductDto.Description = "";
			Product= product;
		}
    }
}
