using CapPlacement.Models;
using CapPlacement.Context;
using CapPlacement.Interfaces.Repositories;
using Microsoft.Azure.Cosmos;

namespace CapPlacement.Implementations.Repositories
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        private readonly CosmosClient _cosmosClient;

        public QuestionRepository(ApplicationContext context, CosmosClient cosmosClient) : base(context, cosmosClient)
        {
            _cosmosClient = cosmosClient;
        }
    }
}
