using Microsoft.Extensions.Options;
using RegistryManagerClient.Models.Entities;
using RegistryManagerClient.Models.ViewModelObjects;
using Optional;
using System.Linq.Expressions;
using System.Reflection;


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

        // TODO turn to Optional
        public T LoadViewModel<T, TEntity>() where T : IViewModelObject<TEntity>, new() where TEntity : class
        {
            var entity = _dbContext.Set<TEntity>().FirstOrDefault(); // Adjust as per your requirements
            if (entity == null)
            {
                throw new Exception("No entity found in the database.");
            }

            var viewModel = new T();
            viewModel.FromEntity(entity);
            return viewModel;
        }

        public List<T> LoadViewModels<T, TEntity>() where T : IViewModelObject<TEntity>, new() where TEntity : class
        {
            var entities = _dbContext.Set<TEntity>().ToList();
            var viewModels = new List<T>();
            foreach (var entity in entities)
            {
                var viewModel = new T();
                viewModel.FromEntity(entity);
                viewModels.Add(viewModel);
            }
            return viewModels;
        }

        public Option<TEntity> FindEntityByKey<TEntity>(object keyValue) where TEntity : class
        {
            TEntity? entity = _dbContext.Set<TEntity>().Find(keyValue);
            return entity == null ? Option.None<TEntity>() : Option.Some(entity);
        }

        public List<T> LoadFilteredViewModels<T, TEntity>(IEnumerable<Expression<Func<TEntity, bool>>> filters) where T : IViewModelObject<TEntity>, new() where TEntity : class
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            foreach (var filter in filters)
            {
                query = query.Where(filter);
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
