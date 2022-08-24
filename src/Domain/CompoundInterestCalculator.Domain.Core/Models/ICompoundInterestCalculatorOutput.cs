namespace CompoundInterestCalculator.Domain.Models;

public interface ICompoundInterestCalculatorOutput
{
    decimal FinalTotalValue { get; set; }
    decimal TotalAmountInvested { get; set; }
    decimal TotalInInterest { get; set; }
    IEnumerable<ICompoundInterestCalculationDetail> Details { get; set; }
}