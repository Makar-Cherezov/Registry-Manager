using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class CargoCategory
{
    public short CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CargoPlace> CargoPlaces { get; set; } = new List<CargoPlace>();
}
