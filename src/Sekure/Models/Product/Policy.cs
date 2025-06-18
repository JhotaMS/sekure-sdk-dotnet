using System;

namespace Sekure.Models
{
    public class Policy
    {
        public string MarketingTracking { get; set; }
        public Guid SessionId { get; set; }
        public ProductDetail ProductDetail { get; set; }
        public PolicyHolder PolicyHolder { get; set; }
        public Quote ConfirmedQuote { get; set; }
        public int Status { get; set; }

    public Policy() { }

        public Policy(string marketingTracking, Guid sessionId, ProductDetail productDetail, PolicyHolder policyHolder, Quote confirmedQuote, int status)
        {
            MarketingTracking = marketingTracking;
            SessionId = sessionId;
            ProductDetail = productDetail;
            PolicyHolder = policyHolder;
            ConfirmedQuote = confirmedQuote;
            Status = status;
        }
    }
}
