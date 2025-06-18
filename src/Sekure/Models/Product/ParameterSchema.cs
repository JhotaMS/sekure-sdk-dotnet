using System;

namespace Sekure.Models;

public class ParameterSchema : ICloneable
{
    public string PropertyId { get; set; }
    public string PropertyName { get; set; }
    public string PropertyValue { get; set; }
    public string PropertyDescription { get; set; }
    public string PropertyTypeDescription { get; set; }
    public int PropertyTypeId { get; set; }
    public string PropertyTypeListValue { get; set; }
    public string PropertyRequired { get; set; }
    public string IsAssistanceType { get; set; }

    public object Clone()
    {
        return new ParameterSchema
        {
            PropertyId = this.PropertyId,
            PropertyName = this.PropertyName,
            PropertyValue = this.PropertyValue,
            PropertyDescription = this.PropertyDescription,
            PropertyTypeDescription = this.PropertyTypeDescription,
            PropertyTypeId = this.PropertyTypeId,
            PropertyTypeListValue = this.PropertyTypeListValue,
            PropertyRequired = this.PropertyRequired,
            IsAssistanceType = this.IsAssistanceType
        };
    }
}