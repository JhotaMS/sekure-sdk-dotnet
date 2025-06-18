using System;

namespace Sekure.Models.RiskValidator
{
    public class ValidationProcess
    {
        public int IdValidationProcess { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public int Step { get; set; }
        public string Status { get; set; }
        public string Detail { get; set; }
        public string TransactionSkrId { get; set; }
        public string InfoValidationProcess { get; set; }
        public bool RunAgainWithoutSteps { get; set; }
        public Guid SubSessionId { get; set; }
        public string IdentificatorId { get; set; }
    }
}
