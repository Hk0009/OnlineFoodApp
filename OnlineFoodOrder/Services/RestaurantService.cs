using Microsoft.EntityFrameworkCore;
using OnlineFoodOrder.Models;
using OnlineFoodOrder.Services;
namespace OnlineFoodOrder.Services
{
    public class RestaurantService :IServices<RestaurantInfo,int>
    {
     private readonly foodieContext _foodContext;
        public RestaurantService(foodieContext _foodContext)
        {
            this._foodContext = _foodContext;

        }
       async Task<RestaurantInfo> IServices<RestaurantInfo,int>.CreateAsync(RestaurantInfo T)
        {
            var res = await _foodContext.RestaurantInfos.AddAsync(T);
            await _foodContext.SaveChangesAsync();
            return res.Entity;
        }
        async Task<IEnumerable<RestaurantInfo>> IServices<RestaurantInfo,int>.GetAsync()
        {
            return await _foodContext.RestaurantInfos.ToListAsync();
             
        }
        async Task<RestaurantInfo> IServices<RestaurantInfo,int>.GetByIdAsync(RestaurantInfo id)
        {
            var res = await _foodContext.RestaurantInfos.FindAsync(id);
            return res;
        }
        async Task<RestaurantInfo> IServices<RestaurantInfo,int>.DeleteAsync(int id)
        {
            var res = await _foodContext.RestaurantInfos.FindAsync(id);
            if (res != null)
            {
                return null;
            }
           
            
                _foodContext.RestaurantInfos.Remove(res);
                await _foodContext.SaveChangesAsync();
              
            
            return res;
        }
        async Task<RestaurantInfo> IServices<RestaurantInfo,int>.UpdateAsync(RestaurantInfo T,int id)
        {
            var res = await _foodContext.RestaurantInfos.FindAsync(id);
            if(res == null)
            {
                return null;
            }

            res.RestaurantName = T.RestaurantName;
            res.Contact=T.Contact;
            res.Description=T.Description;
            await _foodContext.SaveChangesAsync();
            return res;
        }


    }
}

