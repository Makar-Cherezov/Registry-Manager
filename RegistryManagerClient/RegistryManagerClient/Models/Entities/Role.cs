using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class Role
{
    public short RoleId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
