using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class Address
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

    public short DistrictId { get; set; }

    public virtual District District { get; set; } = null!;

    public virtual Client OwnerNavigation { get; set; } = null!;
}
