namespace Sekure.Models;

public class PaymentGatewayProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ConfigurationProduct { get; set; }
    public int PaymentGatewayId { get; set; }

    public PaymentGatewayProduct() { }
}
