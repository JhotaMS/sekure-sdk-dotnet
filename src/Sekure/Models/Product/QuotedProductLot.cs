using System.Collections.Generic;

namespace Sekure.Models;

public class QuotedProductLot
{
    public BatchDetail ProductDetail { get; set; }
    public PolicyHolder PolicyHolder { get; set; }
    public List<Quote> Quotes { get; set; }
}
