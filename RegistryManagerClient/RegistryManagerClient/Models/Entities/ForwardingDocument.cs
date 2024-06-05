using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class ForwardingDocument
{
    public int DocumentId { get; set; }

    public string Title { get; set; } = null!;

    public DateOnly? Date { get; set; }

    public long CargoId { get; set; }

    public virtual Cargo Cargo { get; set; } = null!;
}
