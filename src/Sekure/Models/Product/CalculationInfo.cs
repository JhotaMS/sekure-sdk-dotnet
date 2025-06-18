namespace Sekure.Models
{
    public class CalculationInfo
    {
        public CalculationInfo(
            int id
            , string name
            , string description
            , int presubscribedId
            , int calculationInfoTypeId
            , string value
            , int? order
        )
        {
            Id = id;
            Name = name;
            Description = description;
            PresubscribedId = presubscribedId;
            CalculationInfoTypeId = calculationInfoTypeId;
            Value = value;
            Order = order;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PresubscribedId { get; set; }
        public int CalculationInfoTypeId { get; set; }
        public string Value { get; set; }
        public int? Order { get; set; }
    }
}
