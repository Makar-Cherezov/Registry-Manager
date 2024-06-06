using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class Cargo
{
    public long CargoId { get; set; }

    public string? BillingNumber { get; set; }

    public DateOnly? BillingDate { get; set; }

    public DateOnly? Tfndate { get; set; }

    public string? Tfnnumber { get; set; }

    public short EntrancesCount { get; set; }

    public DateOnly? HandoutDate { get; set; }

    public string? Notes { get; set; }

    public short SchemaId { get; set; }

    public long SenderClient { get; set; }

    public long ReceiverClient { get; set; }

    public long? PaidByClient { get; set; }

    public long RegistryId { get; set; }

    public virtual ICollection<AdditionalPackagingService> AdditionalPackagingServices { get; set; } = new List<AdditionalPackagingService>();

    public virtual ICollection<CargoPlace> CargoPlaces { get; set; } = new List<CargoPlace>();

    public virtual ICollection<ForwardingDocument> ForwardingDocuments { get; set; } = new List<ForwardingDocument>();

    public virtual ICollection<OversizeService> OversizeServices { get; set; } = new List<OversizeService>();

    public virtual Client? PaidByClientNavigation { get; set; }

    public virtual Client ReceiverClientNavigation { get; set; } = null!;

    public virtual ForwardingSchema Schema { get; set; } = null!;

    public virtual Client SenderClientNavigation { get; set; } = null!;
}
