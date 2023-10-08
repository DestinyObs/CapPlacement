using CapPlacement.Models;
using CapPlacement.Context;
using CapPlacement.Interfaces.Repositories;
using TaskProjectWebAPI.Interfaces.Repositories;
using Microsoft.Azure.Cosmos;

namespace CapPlacement.Implementations.Repositories
{
    public class ProgramRepository : GenericRepository<ProgramDetail>, IMyProgramRepository
    {
        private readonly CosmosClient _cosmosClient;

        public ProgramRepository(ApplicationContext context, CosmosClient cosmosClient) : base(context, cosmosClient)
        {
            _cosmosClient = cosmosClient;
        }
    }
}