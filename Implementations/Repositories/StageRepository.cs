using CapPlacement.Models;
using CapPlacement.Context;
using CapPlacement.Interfaces.Repositories;
using Microsoft.Azure.Cosmos;

namespace CapPlacement.Implementations.Repositories
{
    public class StageRepository : GenericRepository<Stage>, IStageRepository
    {
        private readonly CosmosClient _cosmosClient;

        public StageRepository(ApplicationContext context, CosmosClient cosmosClient) : base(context, cosmosClient)
        {
            _cosmosClient = cosmosClient;
        }
    }
}
