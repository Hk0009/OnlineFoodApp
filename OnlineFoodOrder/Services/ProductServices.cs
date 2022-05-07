using Microsoft.EntityFrameworkCore;
using OnlineFoodOrder.Models;
using OnlineFoodOrder.Services;

namespace OnlineFoodOrder.Services
{
    public class ProductServices : IServices<Product,int>
    {
        private readonly foodieContext _foodieContext;
        public ProductServices(foodieContext foodieContext)
        {
            _foodieContext = foodieContext; 
        }
        async Task<IEnumerable<Product>> IServices<Product,int>.GetAsync()
        {
            return await _foodieContext.Products.ToListAsync();  
        }
        async Task<Product> IServices<Product, int>.CreateAsync(Product T)
        {
            var products = await _foodieContext.Products.AddAsync(T);
            await _foodieContext.SaveChangesAsync();
            return products.Entity;
        }
        async Task<Product> IServices<Product,int>.GetByIdAsync(Product id)
        {
            var product = await _foodieContext.Products.FindAsync(id);
            return product;
        }
        async Task<Product> IServices<Product,int>.UpdateAsync(Product products,int id)
        {
            var product = await _foodieContext.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            product.ProductName = products.ProductName;
            product.Price = products.Price;
            product.Quantity = products.Quantity;
            product.Description= products.Description;
            product.Date= products.Date;
            await _foodieContext.SaveChangesAsync();    
            return product;

        }
        async Task<Product> IServices<Product,int>.DeleteAsync(int id)
        {
            var product= await _foodieContext.Products.FindAsync(id);
             _foodieContext.Products.Remove(product);
            return product;

        }
    }
}
