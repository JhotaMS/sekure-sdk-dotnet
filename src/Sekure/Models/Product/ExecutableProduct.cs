using System.Collections.Generic;

namespace Sekure.Models;

public class ExecutableProduct
{
    public string MarketingTracking { get; set; }
    public ProductDetail ProductDetail { get; set; }
    public PolicyHolder PolicyHolder { get; set; }
    public List<InputParameter> Parameters { get; set; }

    public ExecutableProduct(
        string marketingTracking
        , ProductDetail productDetail
        , PolicyHolder policyHolder
        , List<InputParameter> parameters
    )
    {
        MarketingTracking = marketingTracking;
        ProductDetail = productDetail;
        PolicyHolder = policyHolder;
        Parameters = parameters;
    }

    public ExecutableProduct() { }

    public ExecutableProduct(
        ProductDetail productDetail
        , List<InputParameter> parameters
        , string marketingTracking
    )
    {
        ProductDetail = productDetail;
        Parameters = parameters;
        MarketingTracking = marketingTracking;
    }
}