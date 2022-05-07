using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrder.CustomSessions;
using OnlineFoodOrder.Models;
using OnlineFoodOrder.Services;

namespace OnlineFoodOrder.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IServices<FoodCategory, int> foodService;

        public CategoriesController(IServices<FoodCategory, int> foodService)
        {
            this.foodService = foodService;   
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var categoriesData = new FoodCategory();
            var categories = HttpContext.Session.GetObject<FoodCategory>("foodCategory");
            return View(categoriesData);
        }
        [HttpPost]
        public IActionResult Create(FoodCategory foodCategories)
        {
            var foodCategory = foodCategories;
            HttpContext.Session.SetObject<FoodCategory>("foodCategory", foodCategory);
           // var categoryData = foodService.CreateAsync(foodCategories).Result;
            return RedirectToAction("Upload","CategoryUpload");
        }
       

    }
}
