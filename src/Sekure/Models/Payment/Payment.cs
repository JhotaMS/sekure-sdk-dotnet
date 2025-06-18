using System;

namespace Sekure.Models;

public class Payment : Audit
{
    public Guid Id { get; set; }
    public string Detail { get; set; }
    public Guid SessionId { get; set; }
    public virtual Session Session { get; set; }
    public int TenantContactId { get; set; }
    public virtual TenantContact TenantContact { get; set; }

    public Payment() { }
    public Payment(
        string detail
        , Guid sessionId
        , int tenantContactId
        , int user
        , DateTime createdDate
    )
    {
        Detail = detail;
        SessionId = sessionId;
        TenantContactId = tenantContactId;
        User = user;
        CreationDate = createdDate;
    }
}