﻿using CompoundInterestCalculator.Domain.Models.CompoundInterestCalculator;

namespace CompoundInterestCalculator.Domain.Factories;

public sealed class CompoundInterestCalculationDetailFactory : ICompoundInterestCalculationDetailFactory
{
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
