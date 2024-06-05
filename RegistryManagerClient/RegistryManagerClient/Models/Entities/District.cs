using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class District
{
    public short DistrictId { get; set; }

    public string Name { get; set; } = null!;

    public short? CityId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual City? City { get; set; }
}
