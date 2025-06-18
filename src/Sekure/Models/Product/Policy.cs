using System;

namespace Sekure.Models;

public class Policy
{
    public Guid SessionId { get; set; }
    public ProductDetail ProductDetail { get; set; }
    public PolicyHolder PolicyHolder { get; set; }
    public Quote ConfirmedQuote { get; set; }

    public Policy() { }

    public Policy(
        Guid sessionId
        , ProductDetail productDetail
        , PolicyHolder policyHolder
        , Quote confirmedQuote
    )
    {
        SessionId = sessionId;
        ProductDetail = productDetail;
        PolicyHolder = policyHolder;
        ConfirmedQuote = confirmedQuote;
    }
}
