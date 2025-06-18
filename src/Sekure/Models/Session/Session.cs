using System;
using System.Collections.Generic;

namespace Sekure.Models;

public class Session
{
    public Guid Id { get; set; }
    public DateTime CreationDate { get; set; }
    public int TenantContactId { get; set; }
    public virtual TenantContact TenantContact { get; set; }
    public virtual List<Estimate> Estimates { get; set; }
    public virtual List<Product> Products { get; set; }
    public virtual List<Payment> Payments { get; set; }
    public Session() { }

    public Session(
        DateTime creationDate
        , int tenantContactId
    )
    {
        CreationDate = creationDate;
        TenantContactId = tenantContactId;
    }
}