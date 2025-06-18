namespace Sekure.Models;

public class ProductDetail
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string PolicyTypeName { get; set; }
    public string InsuranceCompanyName { get; set; }
    public string ProductCover { get; set; }
    public string DeveloperGuide { get; set; }

    public ProductDetail() { }

    public ProductDetail(
        int productId
        , string productName
        , string policyTypeName
        , string insuranceCompanyName
        , string productCover
        , string developerGuide
    )
    {
        ProductId = productId;
        ProductName = productName;
        PolicyTypeName = policyTypeName;
        InsuranceCompanyName = insuranceCompanyName;
        ProductCover = productCover;
        DeveloperGuide = developerGuide;
    }
}