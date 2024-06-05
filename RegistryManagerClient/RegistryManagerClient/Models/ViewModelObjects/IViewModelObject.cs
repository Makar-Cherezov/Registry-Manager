using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryManagerClient.Models.ViewModelObjects
{
    public abstract class IViewModelObject<TEntity>
    {
        // Default constructor
        public IViewModelObject() { }

        // FromEntity constructor
        public IViewModelObject(TEntity entity)
        {
            FromEntity(entity);
        }

        // Abstract method to initialize ViewModel properties from the entity
        public abstract void FromEntity(TEntity entity);

        // Abstract method to convert ViewModel back to the entity
        public abstract TEntity ToEntity();
    }
}
