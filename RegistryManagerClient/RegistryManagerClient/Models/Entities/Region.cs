using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class Region
{
    public short RegionId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
