using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrder.CustomSessions;
using OnlineFoodOrder.Models;
using OnlineFoodOrder.Services;
using System.Net.Http.Headers;

namespace OnlineFoodOrder.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServices<Product,int> prouctServices;
        IWebHostEnvironment hostEnvironment;
        public ProductController(IServices<Product, int> prouctServices,IWebHostEnvironment hostEnvironment)
        {
           this.prouctServices = prouctServices;
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var product = new Product();
            var productsSession = HttpContext.Session.GetObject<Product>("product");
            return View(product);
        }
        [HttpPost]
        public IActionResult Create(Product products)
        {
            var Products = products;
            HttpContext.Session.SetObject<Product>("product", Products);
            return RedirectToAction("productUpload");
        }
        public IActionResult productUpload()
        {
            ProductUpload data = new ProductUpload();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> productUpload(ProductUpload data)
        {
            IFormFile file = data.image;
            var postedFileName = ContentDispositionHeaderValue
                .Parse(file.ContentDisposition)
                .FileName.Trim('"');
            FileInfo fileInfo = new FileInfo(postedFileName);
            if (fileInfo.Extension == ".jpg" || fileInfo.Extension == ".png")
            {
                var finalPathImage = Path.Combine(hostEnvironment.WebRootPath, "ProductImage", postedFileName);

                using (var fs = new FileStream(finalPathImage, FileMode.Create))
                {
                    // Create a File into the folder
                    await file.CopyToAsync(fs);
                }
                data.imageFileName = @$"~/images/{file.FileName}";
                HttpContext.Session.SetString("imgPath", data.imageFileName);
                data.imageUploadStatus = "File is Uploaded Successfully";
            }
            else
            {
                data.imageUploadStatus = "Failed to Upload Profile Picture......";
                return View(data);
            }
            return RedirectToAction("Index","Restaurant");
        }
    }
}
