namespace Sekure.Models;

public class ProductReference
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PolicyTypeName { get; set; }
    public string InsuranceCompanyName { get; set; }
    public string ProductCover { get; set; }
    public string DevoleperGuide { get; set; }

    public ProductReference() { }

    public ProductReference(
        int id
        , string name
        , string policyTypeName
        , string insuranceCompanyName
        , string productCover
        , string devoleperGuide
    )
    {
        Id = id;
        Name = name;
        PolicyTypeName = policyTypeName;
        InsuranceCompanyName = insuranceCompanyName;
        ProductCover = productCover;
        DevoleperGuide = devoleperGuide;
    }
}
