namespace CompoundInterestCalculator.Application.Queries.CalculateCompoundInterest;

public interface ICalculateCompoundInterestOutput
{
    decimal FinalTotalValue { get; }
    decimal TotalAmountInvested { get; }
    decimal TotalInInterest { get; }
    public IEnumerable<ICalculateCompoundInterestCalculationDetail> Details { get; }
}