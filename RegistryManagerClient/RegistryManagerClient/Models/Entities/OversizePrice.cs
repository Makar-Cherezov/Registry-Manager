using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class OversizePrice
{
    public short OpriceId { get; set; }

    public bool CountsAsVolume { get; set; }

    public float PercentRaise { get; set; }

    public float AbsoluteRaise { get; set; }
}
