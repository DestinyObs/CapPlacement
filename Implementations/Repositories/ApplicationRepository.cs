using CapPlacement.Context;
using CapPlacement.Models;
using CapPlacement.Context;
using CapPlacement.Interfaces.Repositories; 

namespace CapPlacement.Implementations.Repositories
{
    // Define the ApplicationRepository class that implements the IApplicationRepository interface.
    public class ApplicationRepository : GenericRepository<Application>, IApplicationRepository
    {
        // Constructor that takes an ApplicationContext instance and passes it to the base class constructor.
        public ApplicationRepository(ApplicationContext context) : base(context)
        {
            // The "base" keyword is used to call the constructor of the base class (GenericRepository<Application>).
            // This is necessary because the GenericRepository class takes the ApplicationContext as a parameter.
            // The ApplicationContext is used to access the database and perform CRUD operations on the Application entity.
        }
    }
}