using System;
using System.Collections.Generic;

namespace Sekure.Models
{
    public class Quote : ICloneable
    {
        public Guid SessionId { get; set; }
        public string PlanId { get; set; }
        public string PlanNumber { get; set; }
        public string PlanName { get; set; }
        public string PremiumAmount { get; set; }
        public string FormatPremiumAmount { get; set; }
        public string PremiumPaymentInterval { get; set; }
        public string FormatPremiumPaymentInterval { get; set; }
        public string LocalFormatPremiumPaymentInterval { get; set; }
        public string LocalPremiumPaymentInterval { get; set; }
        public string PremiumPaymentIntervalTaxes { get; set; }
        public string FormatPremiumPaymentIntervalWithoutTaxes { get; set; }
        public string PremiumPaymentIntervalWithoutTaxes { get; set; }
        public string StartDate { get; set; }
        public string TermTime { get; set; }
        public string InsuredValue { get; set; }
        public string PolicyNumber { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public string EmailPolicy { get; set; }
        public string AttachName { get; set; }
        public List<AdditionalInfo> QuoteInfo { get; set; }
        public List<Periodicities> Periodicities { get; set; }
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
            Guid sessionId, 
            string planId, 
            string planNumber, 
            string planName, 
            string premiumAmount, 
            string premiumPaymentInterval, 
            string formatPremiumPaymentInterval, 
            string startDate, 
            string termTime, 
            string insuredValue, 
            string policyNumber, 
            string emailSubject, 
            string emailBody, 
            string emailPolicy, 
            string attachName, 
            List<AdditionalInfo> quoteInfo, 
            List<CoverageResultApi> coverages, 
            List<InfoResultApi> deductible, 
            string expeditionDate, string quoteMessage, 
            List<InfoResultApi> beneficiaries, 
            List<InfoResultApi> gracePeriodsList, 
            List<InputParameter> additionalInfo, 
            List<AdditionalInsured> additionalInsured)
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

        public object Clone()
        {
            // Crear una nueva instancia de Quote.
            Quote clonedQuote = new Quote
            {
                SessionId = this.SessionId,
                PlanId = this.PlanId,
                PlanNumber = this.PlanNumber,
                PlanName = this.PlanName,
                PremiumAmount = this.PremiumAmount,
                FormatPremiumAmount = this.FormatPremiumAmount,
                PremiumPaymentInterval = this.PremiumPaymentInterval,
                FormatPremiumPaymentInterval = this.FormatPremiumPaymentInterval,
                StartDate = this.StartDate,
                TermTime = this.TermTime,
                InsuredValue = this.InsuredValue,
                PolicyNumber = this.PolicyNumber,
                EmailSubject = this.EmailSubject,
                EmailBody = this.EmailBody,
                EmailPolicy = this.EmailPolicy,
                AttachName = this.AttachName,
                ExpeditionDate = this.ExpeditionDate,
                QuoteMessage = this.QuoteMessage
            };

            // Clonar las listas si son necesarias (dependiendo de si son objetos mutables).
            if (this.QuoteInfo != null)
            {
                clonedQuote.QuoteInfo = new List<AdditionalInfo>(this.QuoteInfo.Count);
                foreach (var info in this.QuoteInfo)
                {
                    clonedQuote.QuoteInfo.Add(new AdditionalInfo(info.Name, info.Description, info.Value));
                }
            }

            if (this.Periodicities != null)
            {
                clonedQuote.Periodicities = new List<Periodicities>(this.Periodicities.Count);
                foreach (var periodicity in this.Periodicities)
                {
                    clonedQuote.Periodicities.Add(new Periodicities
                    {
                        Type = periodicity.Type,
                        PremiumPaymentIntervalWithoutTaxes = periodicity.PremiumPaymentIntervalWithoutTaxes,
                        FormatPremiumPaymentIntervalWithoutTaxes = periodicity.FormatPremiumPaymentIntervalWithoutTaxes,
                        PremiumPaymentIntervalTaxes = periodicity.PremiumPaymentIntervalTaxes,
                        PremiumPaymentInterval = periodicity.PremiumPaymentInterval,
                        FormatPremiumPaymentInterval = periodicity.FormatPremiumPaymentInterval
                    });
                }
            }

            if (this.Coverages != null)
            {
                clonedQuote.Coverages = new List<CoverageResultApi>(this.Coverages.Count);
                foreach (var coverage in this.Coverages)
                {
                    clonedQuote.Coverages.Add(new CoverageResultApi
                    {
                        TypeCoverage = coverage.TypeCoverage,
                        NameResult = coverage.NameResult,
                        ValueResult = coverage.ValueResult,
                        DescriptionResult = coverage.DescriptionResult,
                        DeductibleResult = coverage.DeductibleResult,
                        IsAssistanceResult = coverage.IsAssistanceResult,
                        AmountInsurance = coverage.AmountInsurance,
                        ShowCoverage = coverage.ShowCoverage
                    });
                }
            }

            if (this.Deductible != null)
            {
                clonedQuote.Deductible = new List<InfoResultApi>(this.Deductible.Count);
                foreach (var deductible in this.Deductible)
                {
                    clonedQuote.Deductible.Add(new InfoResultApi
                    {
                        NameResult = deductible.NameResult,
                        ValueResult = deductible.ValueResult,
                        ComentsResult = deductible.ComentsResult
                    });
                }
            }

            if (this.Beneficiaries != null)
            {
                clonedQuote.Beneficiaries = new List<InfoResultApi>(this.Beneficiaries.Count);
                foreach (var beneficiary in this.Beneficiaries)
                {
                    clonedQuote.Beneficiaries.Add(new InfoResultApi
                    {
                        NameResult = beneficiary.NameResult,
                        ValueResult = beneficiary.ValueResult,
                        ComentsResult = beneficiary.ComentsResult
                    });
                }
            }

            if (this.GracePeriodsList != null)
            {
                clonedQuote.GracePeriodsList = new List<InfoResultApi>(this.GracePeriodsList.Count);
                foreach (var gracePeriod in this.GracePeriodsList)
                {
                    clonedQuote.GracePeriodsList.Add(new InfoResultApi
                    {
                        NameResult = gracePeriod.NameResult,
                        ValueResult = gracePeriod.ValueResult,
                        ComentsResult = gracePeriod.ComentsResult
                    });
                }
            }

            if (this.AdditionalInfo != null)
            {
                clonedQuote.AdditionalInfo = new List<InputParameter>(this.AdditionalInfo.Count);
                foreach (var info in this.AdditionalInfo)
                {
                    clonedQuote.AdditionalInfo.Add((InputParameter)info.Clone());
                }
            }

            if (this.AdditionalInsured != null)
            {
                clonedQuote.AdditionalInsured = new List<AdditionalInsured>(this.AdditionalInsured.Count);
                foreach (var insured in this.AdditionalInsured)
                {
                    clonedQuote.AdditionalInsured.Add(new AdditionalInsured(insured.Name, insured.Description, insured.Value, insured.Coverages));
                }
            }

            return clonedQuote;
        }

    }
    public class Periodicities
    {
        public string Type { get; set; }
        public int PremiumPaymentIntervalWithoutTaxes { get; set; }
        public string FormatPremiumPaymentIntervalWithoutTaxes { get; set; }
        public int PremiumPaymentIntervalTaxes { get; set; }
        public int PremiumPaymentInterval { get; set; }
        public string FormatPremiumPaymentInterval { get; set; }
        public string LocalFormatPremiumPaymentInterval { get; set; }
    }
    public class CoverageResultApi
    {
        public string TypeCoverage { get; set; }
        public string NameResult { get; set; }
        public string ValueResult { get; set; }
        public string DescriptionResult { get; set; }
        public string DeductibleResult { get; set; }
        public string IsAssistanceResult { get; set; }
        public string AmountInsurance { get; set; }
        public bool ShowCoverage { get; set; }
        public List<SubCoverage> SubCoverages { get; set; }
        public CoverageResultApi() { }
    }
    public class SubCoverage
    {
        public string Typecoverage { get; set; }
        public string NameResult { get; set; }
        public string ValueResult { get; set; }
        public string DescriptionResult { get; set; }

        public SubCoverage() { }

        public SubCoverage(string typecoverage, string nameResult, string valueResult, string descriptionResult)
        {
            Typecoverage = typecoverage;
            NameResult = nameResult;
            ValueResult = valueResult;
            DescriptionResult = descriptionResult;
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
