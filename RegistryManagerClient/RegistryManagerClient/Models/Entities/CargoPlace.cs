using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class CargoPlace
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

    public virtual CargoCategory Category { get; set; } = null!;
}
