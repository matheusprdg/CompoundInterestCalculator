namespace CompoundInterestCalculator.Domain.Models.IncomeTaxCalculator;

public class IncomeTaxCalculatorOutput : IIncomeTaxCalculatorOutput
{
    public decimal FinalTotalValue { get; set; }
    public decimal TotalAmountInvested { get; set; }
    public decimal TotalInInterest { get; set; }
    public decimal NetAmount { get; set; }
}