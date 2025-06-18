using System;

namespace Sekure.Models;

public class PaymentDetail
{
    public string PaymentGatewayName { get; set; }
    public string ProductName { get; set; }
    public Guid TransactionSkrId { get; set; }
    public Guid? ClientSkrId { get; set; }
    public object Request { get; set; }

    public PaymentDetail() { }
}
