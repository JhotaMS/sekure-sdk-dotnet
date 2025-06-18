using System;

namespace Sekure.Models;

public class PaymentStatus
{
    public string Policy { get; set; }
    public Guid SessionId { get; set; }
    public int TenantContactId { get; set; }
    public string PaymentGatewayInformation { get; set; }
    public string Status { get; set; }
    public string CoverageNote { get; set; }

    public PaymentStatus() { }
}
