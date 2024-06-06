using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class Registry
{
    public long RegistryId { get; set; }

    public string RegistryCode { get; set; } = null!;

    public string ContainerCode { get; set; } = null!;

    public DateOnly? ShippingDate { get; set; }

    public DateOnly? ArrivalDate { get; set; }

    public string TargetCity { get; set; } = null!;

    public DateTime LastEditedTime { get; set; }

    public short StatusId { get; set; }

    public short Author { get; set; }

    public short LastEditor { get; set; }

    public bool IsCombined { get; set; }

    public virtual User AuthorNavigation { get; set; } = null!;

    public virtual ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();

    public virtual User LastEditorNavigation { get; set; } = null!;

    public virtual RegistryStatus Status { get; set; } = null!;
}
