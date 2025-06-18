namespace Sekure.Models;

public class AdditionalInfo
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Value { get; set; }
    public AdditionalInfo() { }
    public AdditionalInfo(
        string name
        , string description
        , string value
    )
    {
        Name = name;
        Description = description;
        Value = value;
    }
}
