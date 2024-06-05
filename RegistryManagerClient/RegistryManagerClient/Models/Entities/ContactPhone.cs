using System;
using System.Collections.Generic;

namespace RegistryManagerClient.Models.Entities;

public partial class ContactPhone
{
    public long PhoneId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int ContactId { get; set; }

    public virtual ContactPerson Contact { get; set; } = null!;
}
