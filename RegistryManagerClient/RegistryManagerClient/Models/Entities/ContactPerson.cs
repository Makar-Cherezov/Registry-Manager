using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class ContactPerson
{
    public int ContactId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Position { get; set; }

    public int JclientId { get; set; }

    public virtual ICollection<ContactPhone> ContactPhones { get; set; } = new List<ContactPhone>();

    public virtual JuridicalClient Jclient { get; set; } = null!;
}
