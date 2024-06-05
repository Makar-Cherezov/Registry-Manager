using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class ForwardingPrice
{
    public short FpriceId { get; set; }

    public bool CountsForVolume { get; set; }

    public float GradationCeiling { get; set; }

    public float Price { get; set; }
}
