using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class AdditionalPackagingPrice
{
    public short AddPackPriceId { get; set; }

    public string Type { get; set; } = null!;

    public bool CountsAsVolume { get; set; }

    public string Prices { get; set; } = null!;

    public virtual ICollection<AdditionalPackagingService> AdditionalPackagingServices { get; set; } = new List<AdditionalPackagingService>();
}
