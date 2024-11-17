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
        public void OnPost(int? id) {
            if (id == null) {
                Response.Redirect("/Admin/Products/Index");
                return;
            
            }
            if (!ModelState.IsValid) 
            {
                errorMessage = "Please provide all te required fields";
                return;
            }
            var product = context.Products.Find(id);



            if (product == null) 
            {
				Response.Redirect("/Admin/Products/Index");
				return;
			}
            //update the image file if we have a new image file
            string newFileName = product.ImageFileName;
            if(ProductDto.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(ProductDto.ImageFile.FileName);

                string imageFullPath = environment.WebRootPath + "/products/" + newFileName;
                using(var stream = System.IO.File.Create(imageFullPath))
                {
                    ProductDto.ImageFile.CopyTo(stream);

                }
                string oldImageFullPath = environment.WebRootPath + "/products/" + product.ImageFileName;
                System.IO.File.Delete(oldImageFullPath);    
            }

            product.Name = ProductDto.Name;
            product.Brand= ProductDto.Brand;
            product.Category= ProductDto.Category;
            product.Description= ProductDto.Description;
            product.ImageFileName= newFileName;


            context.SaveChanges();


			Product = product;
			successMessage = "Product updated successfully";
			Response.Redirect("/Admin/Products/Index");
		}
    }
}
