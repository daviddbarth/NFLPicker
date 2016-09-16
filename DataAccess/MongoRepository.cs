using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DataAccess
{
    public class MongoRepository<T> : IRepository<T> where T : class, IEntity
    {
        private MongoClient _client;
        private IMongoDatabase _database;
        protected IMongoCollection<T> Collection { get; set; }
        protected string ConnectionString { get; set; }

        public MongoRepository()
            : this(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
        {

        }

        public MongoRepository(string connectionString)
        {
            ConnectionString = connectionString;
            var connUrl = new MongoUrl(connectionString);
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(connUrl.DatabaseName);
            Collection = _database.GetCollection<T>(typeof(T).Name);
        }

        public async Task<List<T>> FindAllAsync()
        {
            return await FindAsync(t => true);
        }

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate, List<string> excludeFields)
        {
            var excludeList = new List<ProjectionDefinition<T>>();

            excludeFields.ForEach(f => excludeList.Add(Builders<T>.Projection.Exclude(f)));

            var projBuildDef = new ProjectionDefinitionBuilder<T>();
            var options = new FindOptions<T>()
            {
                Projection = projBuildDef.Combine(excludeList)
            };

            var cursor = await Collection.FindAsync<T>(predicate, options);

            return await cursor.ToListAsync<T>();
        }

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            var cursor = await Collection.FindAsync<T>(predicate);

            return await cursor.ToListAsync<T>();
        }

        public async Task<T> FindByIdAsync(string id)
        {
            if (id == "0")
                id = "000000000000000000000000";

            var objId = new BsonObjectId(ObjectId.Parse(id));
            var obj = await Collection.FindAsync<T>(x => x.Id == objId);
            var list = await obj.ToListAsync<T>();

            return list.FirstOrDefault();
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            var list = await FindAsync(predicate);

            if (list.Count == 0)
                return null;
            else
                return list.First();

        }

        public async Task<bool> Exists(Expression<Func<T, bool>> predicate)
        {
            var count = await Collection.CountAsync<T>(predicate);

            if (count > 0)
                return true;

            return false;
        }

        public async Task InsertAsync(T entity)
        {
            await Collection.InsertOneAsync(entity);
        }

        public async Task ReplaceOneAsync(Expression<Func<T, bool>> predicate, T entity)
        {
            await Collection.ReplaceOneAsync(predicate, entity);
        }

        public async Task UpdateByIdAsync(T entity)
        {
            await ReplaceOneAsync(e => e.Id == entity.Id, entity);
        }

        public async Task SaveAsync(T entity)
        {
            if (entity.Id == null || entity.Id.ToString() == "000000000000000000000000")
                await InsertAsync(entity);
            else
                await UpdateByIdAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await Collection.DeleteOneAsync(e => e.Id == entity.Id);
        }

        public async Task DeleteByIdAsync(string id)
        {
            var objId = new BsonObjectId(ObjectId.Parse(id));
            await Collection.DeleteOneAsync(e => e.Id == objId);
        }

    }
}
