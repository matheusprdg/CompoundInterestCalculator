using CompoundInterestCalculator.Application.Queries.CalculateIncomeTax;

namespace CompoundInterestCalculator.Api.CalculateIncomeTax;

public class CalculateIncomeTaxInput : ICalculateIncomeTaxInput
{
    public decimal TotalWithInterest { get; set; }
    public decimal TotalInvested { get; set; }
    public decimal TotalInterest { get; set; }
    public int IncomeTaxPeriod { get; set; }
}