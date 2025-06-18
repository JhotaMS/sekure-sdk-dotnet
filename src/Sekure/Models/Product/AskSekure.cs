using System.Collections.Generic;

namespace Sekure.Models
{
    public class AskSekure
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public List<InputParameter> Parameters { get; set; }

        public AskSekure() { }

        public AskSekure(int productId, string productName, List<InputParameter> parameters)
        {
            ProductId = productId;
            ProductName = productName;
            Parameters = parameters;
        }
    }
}