using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class AdditionalPackagingService
{
    public int AddPackId { get; set; }

    public string Parameters { get; set; } = null!;

    public short AddPackPriceId { get; set; }

    public long CargoId { get; set; }

    public virtual AdditionalPackagingPrice AddPackPrice { get; set; } = null!;

    public virtual Cargo Cargo { get; set; } = null!;
}
