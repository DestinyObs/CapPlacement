using CapPlacement.Models;
using CapPlacement.Context;
using CapPlacement.Interfaces.Repositories;

namespace CapPlacement.Implementations.Repositories
{
    public class StageRepository : GenericRepository<Stage>, IStageRepository
    {
        public StageRepository(ApplicationContext context) : base(context)
        {
            
        }
    }
}
