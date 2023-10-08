using CapPlacement.Context;
using CapPlacement.Models;
using CapPlacement.Context;
using CapPlacement.Interfaces.Repositories;
using Microsoft.Azure.Cosmos;

namespace CapPlacement.Implementations.Repositories
{
    // Define the ApplicationRepository class that implements the IApplicationRepository interface.
    public class ApplicationRepository : GenericRepository<Application>, IApplicationRepository
    {
        private readonly CosmosClient _cosmosClient; // Add this field

        // Constructor that takes an ApplicationContext instance and passes it to the base class constructor.
        public ApplicationRepository(ApplicationContext context, CosmosClient cosmosClient) : base(context, cosmosClient)
        {
            _cosmosClient = cosmosClient;
        }
    }
}
