using RegistryManagerClient.Models.Entities;
using RegistryManagerClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RegistryManagerClient.Models.ViewModelObjects
{
    public class ClientVM : IViewModelObject<Client>
    {
        public long ClientId { get; set; }
        public short? Manager { get; set; }
        public string? ManagerName { get; set; }
        public string? Notes { get; set; }
        public bool MinimalCostCalculates { get; set; }
        public bool EntersCalculate { get; set; }
        public bool AddPackagingCalculates { get; set; }
        public bool OversizeCalculates { get; set; }
        public string? PersonalPrices { get; set; }
        public short? ForwarderId { get; set; }
        public string? ForwarderName { get; set; }

        public List<AddressVM> Addresses { get; set; } = new List<AddressVM>();

        // Default constructor
        public ClientVM() { }

        // FromEntity constructor
        public ClientVM(Client client) : base(client) { }

        // Implement FromEntity to initialize ViewModel properties from the entity
        public override void FromEntity(Client client)
        {
            ClientId = client.ClientId;
            Manager = client.Manager;
            Notes = client.Notes;
            MinimalCostCalculates = client.MinimalCostCalculates;
            EntersCalculate = client.EntersCalculate;
            AddPackagingCalculates = client.AddPackagingCalculates;
            OversizeCalculates = client.OversizeCalculates;
            PersonalPrices = client.PersonalPrices;
            ForwarderId = client.ForwarderId;

            ManagerName = client.ManagerNavigation?.Name ?? string.Empty;
            ForwarderName = client.Forwarder?.Name ?? string.Empty;

            // Load Addresses and convert them to AddressVM
            Addresses = client.Addresses.Select(a => new AddressVM(a)).ToList();
        }

        public override Client ToEntity()
        {
            return new Client
            {
                ClientId = ClientId,
                Manager = Manager,
                Notes = Notes,
                MinimalCostCalculates = MinimalCostCalculates,
                EntersCalculate = EntersCalculate,
                AddPackagingCalculates = AddPackagingCalculates,
                OversizeCalculates = OversizeCalculates,
                PersonalPrices = PersonalPrices,
                ForwarderId = ForwarderId,
                Addresses = Addresses.Select(a => a.ToEntity()).ToList()
            };
        }
    }

    
}
