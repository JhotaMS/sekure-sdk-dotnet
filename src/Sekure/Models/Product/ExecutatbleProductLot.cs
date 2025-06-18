using System.Collections.Generic;

namespace Sekure.Models;

public class ExecutatbleProductLot
{
    public BatchDetail BatchDetail { get; set; }
    public List<InputParameter> Parameters { get; set; }
}

public class BatchDetail
{
    public string Name { get; set; }
    public string PolicyTypeName { get; set; }
}
