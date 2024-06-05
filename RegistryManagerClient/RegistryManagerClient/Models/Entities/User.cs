using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class User
{
    public short UserId { get; set; }

    public string Login { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public short RoleId { get; set; }

    public virtual ICollection<Registry> RegistryAuthorNavigations { get; set; } = new List<Registry>();

    public virtual ICollection<Registry> RegistryLastEditorNavigations { get; set; } = new List<Registry>();

    public virtual Role Role { get; set; } = null!;
}
