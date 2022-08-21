namespace CompoundInterestCalculator.Domain.Models;

public class CompoundInterestCalculatorOutput : ICompoundInterestCalculatorOutput
{
    public decimal FinalTotalValue { get; set; }
    public decimal TotalAmountInvested { get; set; }
    public decimal TotalInInterest { get; set; }
}