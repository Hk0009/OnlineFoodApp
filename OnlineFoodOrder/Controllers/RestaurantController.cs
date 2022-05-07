using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrder.CustomSessions;
using OnlineFoodOrder.Models;
using OnlineFoodOrder.Services;

namespace OnlineFoodOrder.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IServices<RestaurantInfo, int> restserv;
        public RestaurantController(IServices<RestaurantInfo, int> restserv)
        {
            this.restserv = restserv;
        }
        public IActionResult Index()
        {
            var rest = restserv.GetAsync().Result.ToList();
            return View(rest);
        }
        public IActionResult Create()
        {

            var restaurantData = new RestaurantInfo();
            var res = HttpContext.Session.GetObject<RestaurantInfo>("restaurantInfo");
            return View(restaurantData);
        }
        [HttpPost]
        public IActionResult Create(RestaurantInfo restaurantDetails)
        {
            var restaurant = restaurantDetails;
            HttpContext.Session.SetObject<RestaurantInfo>("restaurantInfo", restaurant);
           // var restaurantData = restserv.CreateAsync(restaurantDetails).Result;
            return RedirectToAction("Create", "Categories");
        }




    }
}
