using RegistryManagerClient.Models.Entities;
using RegistryManagerClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryManagerClient.Models.ViewModelObjects
{
    public class FullRegistryVM : IViewModelObject<Registry>
    {
        public long RegistryId { get; set; }

        public string RegistryCode { get; set; } = null!;

        public string ContainerCode { get; set; } = null!;

        public DateOnly? ShippingDate { get; set; }

        public DateOnly? ArrivalDate { get; set; }

        public string TargetCity { get; set; } = null!;

        public DateTime LastEditedTime { get; set; }

        public short StatusId { get; set; }

        public short Author { get; set; }

        public short LastEditor { get; set; }

        public bool IsCombined { get; set; }
        public string Status { get; set; }


        // Default constructor
        public FullRegistryVM() { }

        // FromEntity constructor
        public FullRegistryVM(Registry registry) : base(registry) { }

        // Implement FromEntity to initialize ViewModel properties from the entity
        public override void FromEntity(Registry registry)
        {
            RegistryId = registry.RegistryId;
            RegistryCode = registry.RegistryCode;
            ContainerCode = registry.ContainerCode;
            ArrivalDate = registry.ArrivalDate;
            ShippingDate = registry.ShippingDate;
            ArrivalDate = registry.ArrivalDate;
            TargetCity = registry.TargetCity;
            LastEditedTime = registry.LastEditedTime;
            StatusId = registry.StatusId;
            Author = registry.Author;
            LastEditor = registry.LastEditor;
            IsCombined = registry.IsCombined;
            var tryFindStatus = ViewModelObjectsService.Instance.FindEntityByKey<RegistryStatus>(registry.StatusId);
            tryFindStatus.Match(some: entity => Status = entity.Name, none: () => Status = "");
        }

        public override Registry ToEntity()
        {
            return new()
            {
                RegistryId = RegistryId,
                RegistryCode = RegistryCode,
                ContainerCode = ContainerCode,
                ArrivalDate = ArrivalDate,
                ShippingDate = ShippingDate,
                IsCombined = IsCombined,
                Author = Author,
                LastEditedTime = LastEditedTime,
                StatusId = StatusId,
                TargetCity = TargetCity,
                LastEditor = LastEditor,
            };
        }
    }
}
