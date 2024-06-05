using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class ClientPhone
{
    public long PhoneId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int PclientId { get; set; }

    public virtual PhysicalClient Pclient { get; set; } = null!;
}
