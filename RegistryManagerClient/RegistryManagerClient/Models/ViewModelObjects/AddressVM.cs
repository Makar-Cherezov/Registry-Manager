using RegistryManagerClient.Models.Entities;
using RegistryManagerClient.Services;
using System;

namespace RegistryManagerClient.Models.ViewModelObjects
{
    public class AddressVM : IViewModelObject<Address>
    {
        public int AddressId { get; set; }
        public string Name { get; set; } = null!;
        public string? NavigationGuide { get; set; }
        public string? PostIndex { get; set; }
        public string Building { get; set; } = null!;
        public string? Corpus { get; set; }
        public short? Entrance { get; set; }
        public string? Schedule { get; set; }
        public long Owner { get; set; }
        public string? Street { get; set; }
        public short DistrictId { get; set; }
        public string DistrictName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Region {  get; set; } = null!;

        // Default constructor
        public AddressVM() { }

        // FromEntity constructor
        public AddressVM(Address address) : base(address) { }

        // Implement FromEntity to initialize ViewModel properties from the entity
        public override void FromEntity(Address address)
        {
            AddressId = address.AddressId;
            Name = address.Name;
            NavigationGuide = address.NavigationGuide;
            PostIndex = address.PostIndex;
            Building = address.Building;
            Corpus = address.Corpus;
            Entrance = address.Entrance;
            Schedule = address.Schedule;
            Owner = address.Owner;
            Street = address.Street;
            DistrictId = address.DistrictId;
            DistrictName = address.District?.Name ?? string.Empty;
            City = address.District?.City?.Name ?? string.Empty;
            Region = address.District?.City?.Region?.Name ?? string.Empty;
        }

        public override Address ToEntity()
        {
            return new Address
            {
                AddressId = AddressId,
                Name = Name,
                NavigationGuide = NavigationGuide,
                PostIndex = PostIndex,
                Building = Building,
                Corpus = Corpus,
                Entrance = Entrance,
                Schedule = Schedule,
                Owner = Owner,
                Street = Street,
                DistrictId = DistrictId,
                District = new District { DistrictId = DistrictId, Name = DistrictName }
            };
        }
        // Add rest params
        public string GetWholeAddress()
        {
            return $"{Region}, г {City}, р-н {DistrictName}, ул {Street}, д {Building}";
        }
    }
}
