﻿using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class RegistryStatus
{
    public short StatusId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Registry> Registries { get; set; } = new List<Registry>();
}
