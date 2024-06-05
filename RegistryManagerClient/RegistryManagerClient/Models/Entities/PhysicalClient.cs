using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class PhysicalClient
{
    public int PclientId { get; set; }

    public long ClientId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string PassportSeries { get; set; } = null!;

    public string PassportNumber { get; set; } = null!;

    public DateOnly IssueDate { get; set; }

    public string IssuedBy { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<ClientPhone> ClientPhones { get; set; } = new List<ClientPhone>();
}
