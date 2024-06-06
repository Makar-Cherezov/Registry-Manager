using Microsoft.EntityFrameworkCore;
using RegistryManagerClient.Models.Entities;
using RegistryManagerClient.Models.ViewModelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RegistryManagerClient.Services
{
    public class EntitiesObjectsService
    {
        private readonly RegistryManagerContext _dbContext;

        private static readonly Lazy<EntitiesObjectsService> _instance = new Lazy<EntitiesObjectsService>(() => new EntitiesObjectsService());

        private EntitiesObjectsService()
        {
            _dbContext = new RegistryManagerContext();
        }

        public static EntitiesObjectsService Instance => _instance.Value;

        public T LoadEntity<T>(Expression<Func<T, bool>> keyFilter, params string[]? includeProperties) where T : class
        {
            List<Expression<Func<T, bool>>> keylist = new List<Expression<Func<T, bool>>>() { keyFilter };
            return LoadEntities<T>(keylist, includeProperties).FirstOrDefault();
        }
        public List<T> LoadEntities<T>(Expression<Func<T, bool>> filter, params string[]? includeProperties) where T : class
        {
            List<Expression<Func<T, bool>>> keylist = new List<Expression<Func<T, bool>>>() { filter };
            return LoadEntities<T>(keylist, includeProperties);
        }
        public List<T> LoadEntities<T>(IEnumerable<Expression<Func<T, bool>>>? filters = null, params string[]? includeProperties) where T : class
        {
            IQueryable<T> query = _dbContext.Set<T>();
            // Apply Filters
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }
            // Apply Includes
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            var entities = query.ToList();
            
            return entities;
        }
    }
}
