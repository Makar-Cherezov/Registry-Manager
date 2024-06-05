using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class Client
{
    public long ClientId { get; set; }

    public short? Manager { get; set; }

    public string? Notes { get; set; }

    public bool MinimalCostCalculates { get; set; }

    public bool EntersCalculate { get; set; }

    public bool AddPackagingCalculates { get; set; }

    public bool OversizeCalculates { get; set; }

    public string? PersonalPrices { get; set; }

    public short? ForwarderId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Cargo> CargoPaidByClientNavigations { get; set; } = new List<Cargo>();

    public virtual ICollection<Cargo> CargoReceiverClientNavigations { get; set; } = new List<Cargo>();

    public virtual ICollection<Cargo> CargoSenderClientNavigations { get; set; } = new List<Cargo>();

    public virtual Forwarder? Forwarder { get; set; }

    public virtual ICollection<JuridicalClient> JuridicalClients { get; set; } = new List<JuridicalClient>();

    public virtual Manager? ManagerNavigation { get; set; }

    public virtual ICollection<PhysicalClient> PhysicalClients { get; set; } = new List<PhysicalClient>();
}
