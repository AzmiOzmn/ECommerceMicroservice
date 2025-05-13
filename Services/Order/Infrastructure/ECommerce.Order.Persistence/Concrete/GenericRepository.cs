using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Order.Persistence.Concrete
{
    public class GenericRepository<T>(AppDbContext context) : IRepository<T> where T : class
    {
        private readonly DbSet<T> Table = context.Set<T>();
        public async Task CreateAsync(T entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await Table.FindAsync(id);
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();

        }
    }
}
