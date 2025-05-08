using ECommerce.Catalog.Entities.Common;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace ECommerce.Catalog.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> collection;

        public GenericRepository(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            collection = database.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
        }
        public async Task CreateAsync(T entity)
        {
            await collection.InsertOneAsync(entity);

        }

        public async Task DeleteAsync(string id)
        {
            await collection.FindOneAndDeleteAsync(x=>x.Id == id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await collection.AsQueryable().ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
           

        public async Task UpdateAsync(T entity)
        {
            await collection.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity);
        }
    }
}
