using RegistryManagerClient.Models.Entities;
using RegistryManagerClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RegistryManagerClient.Models.ViewModelObjects
{
    public class CargoVM : IViewModelObject<Cargo>
    {
        public long CargoId { get; set; }
        public string? BillingNumber { get; set; }
        public DateOnly? BillingDate { get; set; }
        public DateOnly? Tfndate { get; set; }
        public string? Tfnnumber { get; set; }
        public short EntrancesCount { get; set; }
        public DateOnly? HandoutDate { get; set; }
        public string? Notes { get; set; }
        public short SchemaId { get; set; }
        public long SenderClient { get; set; }
        public long ReceiverClient { get; set; }
        public long? PaidByClient { get; set; }
        public long RegistryId { get; set; }

        public string? PaidByClientName { get; set; }
        public string ReceiverClientName { get; set; } = null!;
        public ClientVM SenderClientVM { get; set; } = null!;

        public List<CargoPlaceVM> CargoPlaces { get; set; } = new List<CargoPlaceVM>();


        // Default constructor
        public CargoVM() { }

        // FromEntity constructor
        public CargoVM(Cargo cargo) : base(cargo) { }

        // Implement FromEntity to initialize ViewModel properties from the entity
        public override void FromEntity(Cargo cargo)
        {
            CargoId = cargo.CargoId;
            BillingNumber = cargo.BillingNumber;
            BillingDate = cargo.BillingDate;
            Tfndate = cargo.Tfndate;
            Tfnnumber = cargo.Tfnnumber;
            EntrancesCount = cargo.EntrancesCount;
            HandoutDate = cargo.HandoutDate;
            Notes = cargo.Notes;
            SchemaId = cargo.SchemaId;
            SenderClient = cargo.SenderClient;
            ReceiverClient = cargo.ReceiverClient;
            PaidByClient = cargo.PaidByClient;
            RegistryId = cargo.RegistryId;
            CargoPlaces = ViewModelObjectsService.Instance
                .LoadViewModels<CargoPlaceVM, CargoPlace>(x => x.CargoId == cargo.CargoId,
                "Category");
            SenderClientVM = ViewModelObjectsService.Instance
                .LoadViewModel<ClientVM, Client>(x => x.ClientId == SenderClient, 
                "JuridicalClients",
                "PhysicalClients",
                "Addresses");
        }

        public override Cargo ToEntity()
        {
            return new Cargo
            {
                CargoId = CargoId,
                BillingNumber = BillingNumber,
                BillingDate = BillingDate,
                Tfndate = Tfndate,
                Tfnnumber = Tfnnumber,
                EntrancesCount = EntrancesCount,
                HandoutDate = HandoutDate,
                Notes = Notes,
                SchemaId = SchemaId,
                SenderClient = SenderClient,
                ReceiverClient = ReceiverClient,
                PaidByClient = PaidByClient,
                RegistryId = RegistryId,
                CargoPlaces = CargoPlaces.Select(cp => cp.ToEntity()).ToList()
            };
        }
    }
}
