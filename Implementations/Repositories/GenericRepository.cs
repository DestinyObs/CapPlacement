using System.Linq.Expressions; 
using System;
using CapPlacement.Models;
using CapPlacement.Interfaces.Repositories;
using CapPlacement.Context; 
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Azure.Cosmos;
using System.Net;

namespace CapPlacement.Implementations.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel, new()
    {
        protected ApplicationContext _context;
        private readonly CosmosClient _cosmosClient;

        // Constructor that takes an ApplicationContext instance and assigns it to the _context field.
        public GenericRepository(ApplicationContext context, CosmosClient cosmosClient)
        {
            _context = context;
            _cosmosClient = cosmosClient;
            // The ApplicationContext is used to access the database and perform CRUD operations on entities of type 'T'.
        }

        // Asynchronously adds the specified entity of type 'T' to the database and saves changes.
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity; // Returns the added entity.
        }

        // Asynchronously checks if any entity of type 'T' satisfies the specified condition represented by the expression.
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AnyAsync(expression);
        }

        // Asynchronously deletes the specified entity of type 'T' from the database and saves changes.
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        // Asynchronously retrieves the entity of type 'T' with the specified 'id' from the database.
        public async Task<T> GetAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        // Asynchronously retrieves all entities of type 'T' from the database.
        public async Task<IEnumerable<T>> GetAllAppsAsync(string databaseName, string containerName)
        {
            try
            {
                var container = _cosmosClient.GetContainer(databaseName, containerName);
                var iterator = container.GetItemQueryIterator<T>();
                var results = new List<T>();

                while (iterator.HasMoreResults)
                {
                    var response = await iterator.ReadNextAsync();
                    results.AddRange(response.ToList());
                }

                return results;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                // Handle collection not found
                return Enumerable.Empty<T>();
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw;
            }
        }


        // Asynchronously retrieves the entity of type 'T' that satisfies the specified condition represented by the expression.
        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).SingleOrDefaultAsync();
        }

        // Asynchronously updates the specified entity of type 'T' in the database and saves changes.
        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity; // Returns the updated entity.
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
