using CompoundInterestCalculator.Domain.Models;

namespace CompoundInterestCalculator.Domain.Factories;

public interface ICompoundInterestCalculationDetailFactory
{
    ICompoundInterestCalculationDetail Create();

    ICompoundInterestCalculationDetail Create(
        int month,
        decimal interest,
        decimal totalInvested,
        decimal totalInterest,
        decimal accumulatedTotal,
        bool initialContribution);
}
