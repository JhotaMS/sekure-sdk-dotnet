using System;
using System.Collections.Generic;

namespace Sekure.Models;

public class Quote
{
    public Guid SessionId { get; set; }
    public string PlanId { get; set; }
    public string PlanNumber { get; set; }
    public string PlanName { get; set; }
    public string PremiumAmount { get; set; }
    public string FormatPremiumAmount { get; set; }
    public string PremiumPaymentInterval { get; set; }
    public string FormatPremiumPaymentInterval { get; set; }
    public string StartDate { get; set; }
    public string TermTime { get; set; }
    public string InsuredValue { get; set; }

    public string PolicyNumber { get; set; }
    public string EmailSubject { get; set; }
    public string EmailBody { get; set; }
    public string EmailPolicy { get; set; }
    public string AttachName { get; set; }
    public List<AdditionalInfo> QuoteInfo { get; set; }
    public List<CoverageResultApi> Coverages { get; set; }
    public List<InfoResultApi> Deductible { get; set; }
    public string ExpeditionDate { get; set; }
    public string QuoteMessage { get; set; }
    public List<InfoResultApi> Beneficiaries { get; set; }
    public List<InfoResultApi> GracePeriodsList { get; set; }
    public List<InputParameter> AdditionalInfo { get; set; }
    public List<AdditionalInsured> AdditionalInsured { get; set; }

    public Quote() { }

    public Quote(
        Guid sessionId
        , string planId
        , string planNumber
        , string planName
        , string premiumAmount
        , string premiumPaymentInterval
        , string formatPremiumPaymentInterval
        , string startDate
        , string termTime
        , string insuredValue
        , string policyNumber
        , string emailSubject
        , string emailBody
        , string emailPolicy
        , string attachName
        , List<AdditionalInfo> quoteInfo
        , List<CoverageResultApi> coverages
        , List<InfoResultApi> deductible
        , string expeditionDate
        , string quoteMessage
        , List<InfoResultApi> beneficiaries
        , List<InfoResultApi> gracePeriodsList
        , List<InputParameter> additionalInfo
        , List<AdditionalInsured> additionalInsured
    )
    {
        SessionId = sessionId;
        PlanId = planId;
        PlanNumber = planNumber;
        PlanName = planName;
        PremiumAmount = premiumAmount;
        PremiumPaymentInterval = premiumPaymentInterval;
        FormatPremiumPaymentInterval = formatPremiumPaymentInterval;
        StartDate = startDate;
        TermTime = termTime;
        InsuredValue = insuredValue;
        PolicyNumber = policyNumber;
        EmailSubject = emailSubject;
        EmailBody = emailBody;
        EmailPolicy = emailPolicy;
        AttachName = attachName;
        QuoteInfo = quoteInfo;
        Coverages = coverages;
        Deductible = deductible;
        ExpeditionDate = expeditionDate;
        QuoteMessage = quoteMessage;
        Beneficiaries = beneficiaries;
        GracePeriodsList = gracePeriodsList;
        AdditionalInfo = additionalInfo;
        AdditionalInsured = additionalInsured;
    }
}
public class InfoResultApi
{
    public string NameResult { get; set; }
    public string ValueResult { get; set; }
    public string ComentsResult { get; set; }

    public InfoResultApi() { }
}

public class EndOfValidityPremium
{
    public string Name { get; set; }
    public string Value { get; set; }
    public string Comments { get; set; }

}
