namespace CompoundInterestCalculator.Domain.Models.IncomeTaxCalculator;

public interface IIncomeTaxCalculatorInput
{
    decimal TotalWithInterest { get; set; }
    decimal TotalInvested { get; set; }
    decimal TotalInterest { get; set; }
    IncomeTaxPeriod IncomeTaxPeriod { get; set; }
}