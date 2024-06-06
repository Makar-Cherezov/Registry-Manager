using RegistryManagerClient.Models.Entities;
using RegistryManagerClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryManagerClient.Models.ViewModelObjects
{
    public class CargoPlaceVM : IViewModelObject<CargoPlace>
    {
        public long PlaceId { get; set; }
        public long CargoId { get; set; }
        public float? Weight { get; set; }
        public float? Volume { get; set; }
        public float? Length { get; set; }
        public float? Width { get; set; }
        public float? Height { get; set; }
        public short PlacesCount { get; set; }
        public string? OriginalPackage { get; set; }
        public string? OriginalCondition { get; set; }
        public short CategoryId { get; set; }
        public string CategoryName { get; set; }

        // Default constructor
        public CargoPlaceVM() { }

        // FromEntity constructor
        public CargoPlaceVM(CargoPlace cargoPlace) : base(cargoPlace) { }

        // Implement FromEntity to initialize ViewModel properties from the entity
        public override void FromEntity(CargoPlace cargoPlace)
        {
            PlaceId = cargoPlace.PlaceId;
            CargoId = cargoPlace.CargoId;
            Weight = cargoPlace.Weight;
            Volume = cargoPlace.Volume;
            Length = cargoPlace.Length;
            Width = cargoPlace.Width;
            Height = cargoPlace.Height;
            PlacesCount = cargoPlace.PlacesCount;
            OriginalPackage = cargoPlace.OriginalPackage;
            OriginalCondition = cargoPlace.OriginalCondition;
            CategoryId = cargoPlace.CategoryId;
            CategoryName = cargoPlace.Category.Name;
        }

        public override CargoPlace ToEntity()
        {
            return new CargoPlace
            {
                PlaceId = PlaceId,
                CargoId = CargoId,
                Weight = Weight,
                Volume = Volume,
                Length = Length,
                Width = Width,
                Height = Height,
                PlacesCount = PlacesCount,
                OriginalPackage = OriginalPackage,
                OriginalCondition = OriginalCondition,
                CategoryId = CategoryId
            };
        }
    }
}
