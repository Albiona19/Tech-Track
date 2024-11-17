using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechTrack.Models;
using TechTrack.Services;

namespace TechTrack.Pages.Admin.Products
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;
        [BindProperty]
        public ProductDto ProductDto { get; set; } = new ProductDto();

        public CreateModel(IWebHostEnvironment environment, ApplicationDbContext context) {
            this.environment = environment;
            this.context= context;
        }
        public void OnGet()
        {
        }

        public string errorMessage = "";
		public string successMessage = "";

		public void OnPost()
        {
            if (ProductDto.ImageFile==null) {
                ModelState.AddModelError("ProductDto.ImageFile", "The image file is required");
           }
            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields!";
                return;

            }
        }
    }
}
