using System.Collections.Generic;
using System.Threading.Tasks;
namespace OnlineFoodOrder.Services
{
    public interface IServices<TEntity,in TPk> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetByIdAsync(TEntity id);
        Task<TEntity> CreateAsync(TEntity T);
        Task<TEntity> UpdateAsync(TEntity T,TPk id);  
        Task<TEntity> DeleteAsync(TPk id);

    }
}
