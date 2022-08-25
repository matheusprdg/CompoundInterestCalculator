namespace CompoundInterestCalculator.Domain.Models.CompoundInterestCalculator;

public interface ICompoundInterestCalculationDetail
{
    public int Month { get; }
    public decimal Interest { get; }
    public decimal TotalInvested { get; }
    public decimal TotalInterest { get; }
    public decimal AccumulatedTotal { get; }
    public bool InitialContribution { get; }
}