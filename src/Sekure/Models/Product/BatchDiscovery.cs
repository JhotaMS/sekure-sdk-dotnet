using System.Collections.Generic;

namespace Sekure.Models;

public class BatchDiscovery
{
    public BatchDetail BatchDetail { get; set; }
    public List<InputParameter> Quote { get; set; }
    public List<InputParameter> Confirm { get; set; }
    public List<InputParameter> ToEmit { get; set; }
}
