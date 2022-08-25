using CompoundInterestCalculator.Domain.Factories;
using CompoundInterestCalculator.Domain.Models;
using CompoundInterestCalculator.Domain.Models.CompoundInterestCalculator;

namespace CompoundInterestCalculator.Domain.Calculators;

public class CompoundInterestCalculator : ICompoundInterestCalculator
{
    private readonly ICompoundInterestCalculationDetailFactory calculationDetailFactory;
    private int PeriodInMonths;
    private decimal InterestPercentageInMonths;
    private decimal TotalInvested;
    private bool HasInitialContribution;

    public CompoundInterestCalculator(ICompoundInterestCalculationDetailFactory calculationDetailFactory)
    {
        this.calculationDetailFactory = calculationDetailFactory;
    }

    public ICompoundInterestCalculatorOutput Calculate(ICompoundInterestCalculatorInput input, CancellationToken cancellationToken)
    {
        this.SetProperties(input);

        var periodLength = this.HasInitialContribution 
            ? this.PeriodInMonths + 1 
            : this.PeriodInMonths;

        var totalWithInterest = 0m;
        var details = new List<ICompoundInterestCalculationDetail>();

        for (int i = 0; i < periodLength; i++)
        {
            if (i == 0 && this.HasInitialContribution)
            {
                totalWithInterest += input.InitialContribution!.Value;
                
                details.Add(this.calculationDetailFactory.Create(
                    i, 
                    0,
                    totalWithInterest.RoundWithTwoDigits(),
                    0,
                    totalWithInterest.RoundWithTwoDigits(),
                    true));

                continue;
            }

            var interest = totalWithInterest * (this.InterestPercentageInMonths / 100);
            totalWithInterest += input.MonthlyValue.GetValueOrDefault() + (totalWithInterest * (this.InterestPercentageInMonths / 100));
            var totalInvestedSoFar = input.MonthlyValue.GetValueOrDefault() * (i + 1);

            details.Add(this.calculationDetailFactory.Create(
                    i,
                    interest.RoundWithTwoDigits(),
                    totalInvestedSoFar.RoundWithTwoDigits(),
                    (totalWithInterest - totalInvestedSoFar).RoundWithTwoDigits(),
                    totalWithInterest.RoundWithTwoDigits(),
                    false));
        }

        var interestTotal = totalWithInterest - this.TotalInvested;

        return new CompoundInterestCalculatorOutput
        {
            FinalTotalValue = totalWithInterest.RoundWithTwoDigits(),
            TotalAmountInvested = this.TotalInvested,
            TotalInInterest = interestTotal.RoundWithTwoDigits(),
            Details = details
        };
    }

    private void SetProperties(ICompoundInterestCalculatorInput input)
    {
        this.InterestPercentageInMonths =
            input.InterestType == InterestType.Monthly
            ? input.InterestPercentage
            : input.InterestPercentage / 12;

        this.PeriodInMonths  =
            input.PeriodType == PeriodType.Monthly
            ? input.Period
            : input.Period * 12;

        this.HasInitialContribution = input.InitialContribution.HasValue && input.InitialContribution.Value > 0;

        this.TotalInvested =
            this.HasInitialContribution
            ? input.InitialContribution!.Value + (input.MonthlyValue.GetValueOrDefault() * this.PeriodInMonths)
            : (input.MonthlyValue.GetValueOrDefault() * this.PeriodInMonths);
    }
}