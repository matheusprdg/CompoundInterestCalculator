namespace CompoundInterestCalculator.Application.Queries.CalculateCompoundInterest;

public class CalculateCompoundInterestCalculationDetail : ICalculateCompoundInterestCalculationDetail
{
    public CalculateCompoundInterestCalculationDetail(
        int month,
        decimal interest,
        decimal totalInvested,
        decimal totalInterest,
        decimal accumulatedTotal,
        bool initialContribution)
    {
        this.Month = month;
        this.Interest = interest;
        this.TotalInvested = totalInvested;
        this.TotalInterest = totalInterest;
        this.AccumulatedTotal = accumulatedTotal;
        this.InitialContribution = initialContribution;
    }

    public int Month { get; init; }
    public decimal Interest { get; init; }
    public decimal TotalInvested { get; init; }
    public decimal TotalInterest { get; init; }
    public decimal AccumulatedTotal { get; init; }
    public bool InitialContribution { get; init; }
}