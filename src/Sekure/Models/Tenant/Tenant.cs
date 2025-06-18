using System;
using System.Collections.Generic;

namespace Sekure.Models;

public class Tenant
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Details { get; set; }
    public virtual List<TenantContact> TenantContats { get; set; }
    public Tenant() { }

    public Tenant(Guid id, string name, string details)
    {
        Id = id;
        Name = name;
        Details = details;
    }
}