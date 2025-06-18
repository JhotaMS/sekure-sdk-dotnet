using System;

namespace Sekure.Models
{
    public class Estimate : Audit
    {
        public int Id { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public int TenantContactId { get; set; }
        public virtual TenantContact TenantContact { get; set; }
        public Guid SessionId { get; set; }
        public virtual Session Session { get; set; }
        public int? Status { get; set; }
        public int? StatusReport { get; set; }
        public int? IdProduct { get; set; }

    public Estimate() { }

    public Estimate(
        string request
        , string response
        , int tenantContactId
        , Guid sessionId
        , int user
        , DateTime creationDate
        , byte[] modifiedDate
    )
    {
        Request = request;
        Response = response;
        TenantContactId = tenantContactId;
        SessionId = sessionId;
        User = user;
        CreationDate = creationDate;
        ModifiedDate = modifiedDate;
    }
}