using CapPlacement.Models;
using CapPlacement.Context;
using CapPlacement.Interfaces.Repositories;

namespace CapPlacement.Implementations.Repositories
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationContext context) : base(context)
        {
            
        }
    }
}
