using CompoundInterestCalculator.Domain.Models.CompoundInterestCalculator;

namespace CompoundInterestCalculator.Domain.Factories;

public interface ICompoundInterestCalculationDetailFactory
{
    ICompoundInterestCalculationDetail Create(
        int month,
        decimal interest,
        decimal totalInvested,
        decimal totalInterest,
        decimal accumulatedTotal,
        bool initialContribution);
}
