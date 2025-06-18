using System.Collections.Generic;

namespace Sekure.Models;

public class CoverageResultApi
{
    public string TypeCoverage { get; set; }
    public string NameResult { get; set; }
    public string ValueResult { get; set; }
    public string DescriptionResult { get; set; }
    public string DeductibleResult { get; set; }
    public string IsAssistanceResult { get; set; }
    public string AmountInsurance { get; set; }
    public bool ShowCoverage { get; set; }
    public List<SubCoverage> SubCoverages { get; set; }
    public CoverageResultApi() { }
}
