using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class ForwardingSchema
{
    public short SchemaId { get; set; }

    public string Name { get; set; } = null!;

    public float MinimalCost { get; set; }

    public virtual ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();
}
