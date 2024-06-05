using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class OversizeService
{
    public int OserviceId { get; set; }

    public float? AbsoluteRaise { get; set; }

    public float? PercentRaise { get; set; }

    public bool CalculatesInPercents { get; set; }

    public float? Weight { get; set; }

    public float? Length { get; set; }

    public float? Width { get; set; }

    public float? Height { get; set; }

    public long CargoId { get; set; }

    public virtual Cargo Cargo { get; set; } = null!;
}
