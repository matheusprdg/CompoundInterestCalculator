using CompoundInterestCalculator.Domain.Models;

namespace CompoundInterestCalculator.Domain.Factories;

public class CompoundInterestCalculationDetailFactory : ICompoundInterestCalculationDetailFactory
{
    public ICompoundInterestCalculationDetail Create()
    {
        return new CompoundInterestCalculationDetail();
    }

    public ICompoundInterestCalculationDetail Create(
        int month,
        decimal interest,
        decimal totalInvested,
        decimal totalInterest,
        decimal accumulatedTotal,
        bool initialContribution)
    {
        return new CompoundInterestCalculationDetail(
            month,
            interest,
            totalInvested,
            totalInterest,
            accumulatedTotal,
            initialContribution);
    }
}
