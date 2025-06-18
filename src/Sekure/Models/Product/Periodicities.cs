namespace Sekure.Models;

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
