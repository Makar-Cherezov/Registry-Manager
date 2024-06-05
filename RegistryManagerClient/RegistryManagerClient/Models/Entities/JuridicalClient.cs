using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class JuridicalClient
{
    public int JclientId { get; set; }

    public long ClientId { get; set; }

    public string Inn { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<ContactPerson> ContactPeople { get; set; } = new List<ContactPerson>();
}
