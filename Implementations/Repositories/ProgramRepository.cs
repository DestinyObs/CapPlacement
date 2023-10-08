using CapPlacement.Models;
using CapPlacement.Context;
using CapPlacement.Interfaces.Repositories;
using TaskProjectWebAPI.Interfaces.Repositories;

namespace CapPlacement.Implementations.Repositories
{
    public class ProgramRepository : GenericRepository<ProgramDetail>, IMyProgramRepository
    {
        public ProgramRepository(ApplicationContext context) : base(context)
        {
        }
    }
}