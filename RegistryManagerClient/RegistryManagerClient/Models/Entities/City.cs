using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class City
{
    public short CityId { get; set; }

    public string Name { get; set; } = null!;

    public short? RegionId { get; set; }

    public virtual ICollection<District> Districts { get; set; } = new List<District>();

    public virtual Region? Region { get; set; }
}
