using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrder.Models;
using OnlineFoodOrder.Services;
using System.Net.Http.Headers;

namespace OnlineFoodOrder.Controllers
{
    public class CategoryUploadController : Controller
    {
        //the benefit is that you can't inadvertently change it from another part of that class after it is initialized.
        // private readonly IServices<FoodCategory> _foodCategories;
        IWebHostEnvironment hostEnvironment;
        private readonly IServices<FoodCategory, int> foodCategoryServices;
        public CategoryUploadController(IServices<FoodCategory, int> foodCategoryServices, IWebHostEnvironment hostEnvironment)
        {
            this.foodCategoryServices = foodCategoryServices;
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upload()
        {
           CategoryUpload  data = new CategoryUpload();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Upload(CategoryUpload data)
        {
            //try
            //{

            //}
            //catch (Exception exception)
            //{
            //}
            IFormFile file = data.image;
            var postedFileName = ContentDispositionHeaderValue
               .Parse(file.ContentDisposition)
                 .FileName.Trim('"');
            FileInfo fileInfo = new FileInfo(postedFileName);
            if(fileInfo.Extension==".jpg" || fileInfo.Extension==".png")
            {
                var finalPathImage = Path.Combine(hostEnvironment.WebRootPath, "categoryImage", postedFileName);
                using (var fs = new FileStream(finalPathImage, FileMode.Create))
                {
                    // Create a File into the folder
                    await file.CopyToAsync(fs);
                }
                data.imageFileName = $@"~/images/{file.FileName}";
               HttpContext.Session.SetString("imgPath", data.imageFileName);
                data.imageUploadStatus = "File Uploaded Sucessfully";

            }
            else
            {
                data.imageUploadStatus = "Failed to Upload Category image";
                return View(data);
            }
            return RedirectToAction("Create","Product");
        }

    }
}
