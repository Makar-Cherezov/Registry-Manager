using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class Manager
{
    public short ManagerId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
