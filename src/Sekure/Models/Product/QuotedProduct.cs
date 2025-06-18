using System;
using System.Collections.Generic;

namespace Sekure.Models;

public class QuotedProduct
{
    public string MarketingTracking { get; set; }
    public Guid SessionId { get; set; }
    public ProductDetail ProductDetail { get; set; }
    public PolicyHolder PolicyHolder { get; set; }
    public List<Quote> Quotes { get; set; }

    public QuotedProduct()
    {

    }

    public QuotedProduct(
        ProductDetail productDetail
        , PolicyHolder policyHolder
        , List<Quote> quotes
        , string marketingTracking
    )
    {
        MarketingTracking = marketingTracking;
        ProductDetail = productDetail;
        PolicyHolder = policyHolder;
        Quotes = quotes;
    }
}
