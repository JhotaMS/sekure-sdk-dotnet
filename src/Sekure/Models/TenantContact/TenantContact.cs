using System;
using System.Collections.Generic;

namespace Sekure.Models;

public class TenantContact
{
    public int Id { get; set; }
    public Guid TenantId { get; set; }
    public virtual Tenant Tenant { get; set; }
    public string Email { get; set; }
    public string Details { get; set; }
    public virtual List<Session> Sessions { get; set; }
    public virtual List<Estimate> Estimates { get; set; }
    public virtual List<Product> Products { get; set; }
    public virtual List<Payment> Payments { get; set; }
    public TenantContact() { }

    public TenantContact(int id, Guid tenantId, string email, string details)
    {
        Id = id;
        TenantId = tenantId;
        Email = email;
        Details = details;
    }
}