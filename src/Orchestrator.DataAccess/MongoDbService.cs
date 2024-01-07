using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Orchestrator.DataAccess.Models;
using Orchestrator.DataAccess.Options;

namespace Orchestrator.DataAccess
{
    public class MongoDbService
    {
        private readonly MongoDbOptions mongoDBOptions;

        public MongoDbService(IOptions<MongoDbOptions> mongoDbOptions)
        {
            if(mongoDbOptions is null)
            {
                throw new ArgumentNullException("Invalid configuration for MongoDB.");
            }

            this.mongoDBOptions = mongoDbOptions.Value;
        }

        public async Task InsertAsync(WorkflowModel entity)
        {
            var collection = GetCollection();

            await collection.InsertOneAsync(entity);
        }

        private IMongoCollection<WorkflowModel> GetCollection()
        {
            return new MongoClient(mongoDBOptions.ConnectionUri)
                .GetDatabase(mongoDBOptions.DatabaseName)
                .GetCollection<WorkflowModel>(mongoDBOptions.CollectionName);
        }
    }
}
