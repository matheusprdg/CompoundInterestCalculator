namespace CompoundInterestCalculator.Domain.Models.CompoundInterestCalculator;

public class CompoundInterestCalculatorOutput : ICompoundInterestCalculatorOutput
{
    public decimal FinalTotalValue { get; set; }
    public decimal TotalAmountInvested { get; set; }
    public decimal TotalInInterest { get; set; }
    public IEnumerable<ICompoundInterestCalculationDetail> Details { get; set; }
}