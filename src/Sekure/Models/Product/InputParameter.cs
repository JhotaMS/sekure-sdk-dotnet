using System;
using System.Collections.Generic;

namespace Sekure.Models;

public class InputParameter : ICloneable
{
    public string Name { get; set; }
    public int InputParameterId { get; set; }
    public string InputParameterType { get; set; }
    public string InputParameterValue { get; set; }
    public string InputParameterDescription { get; set; }
    public string InputParameterRequired { get; set; }
    public bool ShowApi { get; set; }
    public List<ParameterSchema> InputParameterSchemaList { get; set; }
    public List<InputParameter> InputParameterArrayObjectList { get; set; }

    public InputParameter()
    {
    }
    public object Clone()
    {
        // Crear una nueva instancia de InputParameter.
        InputParameter clonedParameter = new InputParameter
        {
            // Copiar los valores de las propiedades desde la instancia actual a la nueva instancia.
            Name = this.Name,
            InputParameterId = this.InputParameterId,
            InputParameterType = this.InputParameterType,
            InputParameterValue = this.InputParameterValue,
            InputParameterDescription = this.InputParameterDescription,
            InputParameterRequired = this.InputParameterRequired,
            ShowApi = this.ShowApi
        };

        // Clonar las listas si son necesarias (dependiendo de si son objetos mutables).
        if (this.InputParameterSchemaList != null)
        {
            clonedParameter.InputParameterSchemaList = new List<ParameterSchema>(this.InputParameterSchemaList.Count);
            foreach (var schema in this.InputParameterSchemaList)
            {
                clonedParameter.InputParameterSchemaList.Add((ParameterSchema)schema.Clone());
            }
        }

        if (this.InputParameterArrayObjectList != null)
        {
            clonedParameter.InputParameterArrayObjectList = new List<InputParameter>(this.InputParameterArrayObjectList.Count);
            foreach (var parameter in this.InputParameterArrayObjectList)
            {
                clonedParameter.InputParameterArrayObjectList.Add((InputParameter)parameter.Clone());
            }
        }

        return clonedParameter;
    }
}
