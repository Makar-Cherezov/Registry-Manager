using RegistryManagerClient.Models.Entities;
using RegistryManagerClient.Models.ViewModelObjects;
using RegistryManagerClient.Services;
using System.ComponentModel.DataAnnotations;

namespace RegistryManagerClient.Models.ViewModelObjects
{
    public class RegistryViewModel : IViewModelObject<Registry>
    {
        public long RegistryId { get; set; }
        public string RegistryCode { get; set; } = null!;
        public DateOnly? ArrivalDate { get; set; }
        public string Status { get; set; }
        public string Author { get; set; }
        public short StatusId { get; set; }

        public short AuthorId { get; set; }


        // Default constructor
        public RegistryViewModel() { }

        // FromEntity constructor
        public RegistryViewModel(Registry registry) : base(registry) { }

        // Implement FromEntity to initialize ViewModel properties from the entity
        public override void FromEntity(Registry registry)
        {
            RegistryId = registry.RegistryId;
            RegistryCode = registry.RegistryCode;
            
            ArrivalDate = registry.ArrivalDate;
            StatusId = registry.StatusId;
            Status = registry.Status.Name;
            AuthorId = registry.Author;
            Author = $"{registry.AuthorNavigation.Name} {registry.AuthorNavigation.Name}";

        }

        // ViewModel only for reading
        public override Registry ToEntity()
        {
            throw new NotImplementedException();
        }
    }
}
