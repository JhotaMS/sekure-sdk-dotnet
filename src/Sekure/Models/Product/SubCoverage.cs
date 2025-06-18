namespace Sekure.Models;

public class SubCoverage
{
    public string Typecoverage { get; set; }
    public string NameResult { get; set; }
    public string ValueResult { get; set; }
    public string DescriptionResult { get; set; }

    public SubCoverage() { }

    public SubCoverage(
        string typecoverage
        , string nameResult
        , string valueResult
        , string descriptionResult
    )
    {
        Typecoverage = typecoverage;
        NameResult = nameResult;
        ValueResult = valueResult;
        DescriptionResult = descriptionResult;
    }
}
