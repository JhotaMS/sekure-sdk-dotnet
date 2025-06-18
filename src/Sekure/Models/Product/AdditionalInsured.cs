using System.Collections.Generic;

namespace Sekure.Models;

public class AdditionalInsured
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Value { get; set; }
    public List<CoverageResultApi> Coverages { get; set; }

    public AdditionalInsured() { }

    public AdditionalInsured(
        string name
        , string description
        , string value
        , List<CoverageResultApi> coverages
    )
    {
        Name = name;
        Description = description;
        Value = value;
        Coverages = coverages;
    }
}
