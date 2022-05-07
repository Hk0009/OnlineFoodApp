using Microsoft.EntityFrameworkCore;
using OnlineFoodOrder.Models;
using OnlineFoodOrder.Services;
namespace OnlineFoodOrder.Services
{
    public class CategoriesServices : IServices<FoodCategory, int>
    {
        private readonly foodieContext _foodContext;
        public CategoriesServices(foodieContext _foodContext)
        {
            this._foodContext = _foodContext;

        }
        async Task<FoodCategory> IServices<FoodCategory, int>.CreateAsync(FoodCategory T)
        {
            var foodCategory = await _foodContext.FoodCategories.AddAsync(T);
            await _foodContext.SaveChangesAsync();
            return foodCategory.Entity;
        }
        async Task<IEnumerable<FoodCategory>> IServices<FoodCategory, int>.GetAsync()
        {
            return await _foodContext.FoodCategories.ToListAsync();

        }
        async Task<FoodCategory> IServices<FoodCategory, int>.GetByIdAsync(FoodCategory id)
        {
            var res = await _foodContext.FoodCategories.FindAsync(id);
            return res;
        }
        async Task<FoodCategory> IServices<FoodCategory, int>.DeleteAsync(int id)
        {
            var res = await _foodContext.FoodCategories.FindAsync(id);
            if (res != null)
            {
                return null;
            }


            _foodContext.FoodCategories.Remove(res);
            await _foodContext.SaveChangesAsync();


            return res;
        }
        async Task<FoodCategory> IServices<FoodCategory, int>.UpdateAsync(FoodCategory T, int id)
        {
            var res = await _foodContext.FoodCategories.FindAsync(id);
            if (res == null)
            {
                return null;
            }

            res.CategoryName = T.CategoryName;
            res.ImageUrl = T.ImageUrl;
            res.Date = T.Date;
            await _foodContext.SaveChangesAsync();
            return res;
        }


    }
}

