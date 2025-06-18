using System;
using System.Collections.Generic;

namespace Sekure.Models.RiskValidator
{
    public class ExecutableRiskValidator
    {
        public string TransactionSkrId { get; set; }
        public string ValidatorKey { get; set; }
        public string IdentificatorId { get; set; }
        public IDictionary<string, string> Parameters { get; set; }
        public List<object> Help { get; set; }
        public string Status { get; set; }
        public string InfoValidationProcess { get; set; }
        public string AdditionalMessage { get; set; }
        public Guid SubSessionId { get; set; }
    }
}
