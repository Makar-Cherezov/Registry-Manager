using Microsoft.Extensions.Options;
using RegistryManagerClient.Models.Entities;
using RegistryManagerClient.Models.ViewModelObjects;
using Optional;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using System.Windows.Navigation;
using System.Collections.Generic;


namespace RegistryManagerClient.Services
{
    public class ViewModelObjectsService
    {

        private readonly RegistryManagerContext _dbContext;

        private static readonly Lazy<ViewModelObjectsService> _instance = new Lazy<ViewModelObjectsService>(() => new ViewModelObjectsService());

        private ViewModelObjectsService()
        {
            _dbContext = new RegistryManagerContext();
        }

        public static ViewModelObjectsService Instance => _instance.Value;

        public T LoadViewModel<T, TEntity>(Expression<Func<TEntity, bool>> keyFilter, params string[]? includeProperties) where T : IViewModelObject<TEntity>, new() where TEntity : class
        {
            List < Expression < Func<TEntity, bool> >> keylist = new List<Expression<Func<TEntity, bool>>>() { keyFilter};
            return LoadViewModels<T, TEntity>(keylist, includeProperties).FirstOrDefault();
        }

        public List<T> LoadViewModels<T, TEntity>(IEnumerable<Expression<Func<TEntity, bool>>>? filters = null, params string[]? includeProperties) where T : IViewModelObject<TEntity>, new() where TEntity : class
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
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
            var viewModels = new List<T>();
            foreach (var entity in entities)
            {
                var viewModel = new T();
                viewModel.FromEntity(entity);
                viewModels.Add(viewModel);
            }
            return viewModels;
        }

    }
}
