using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class Forwarder
{
    public short ForwarderId { get; set; }

    public string Inn { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Kpp { get; set; } = null!;

    public string Ogrn { get; set; } = null!;

    public string PaymentAccount { get; set; } = null!;

    public string Okpo { get; set; } = null!;

    public string Bank { get; set; } = null!;

    public string CorrespondentAccount { get; set; } = null!;

    public string Bik { get; set; } = null!;

    public string CeofullName { get; set; } = null!;

    public string AccountantFullName { get; set; } = null!;

    public bool Ndflcalculates { get; set; }

    public string JuridicalAddress { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
