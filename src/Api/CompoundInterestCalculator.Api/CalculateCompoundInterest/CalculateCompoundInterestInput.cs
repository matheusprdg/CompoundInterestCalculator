using CompoundInterestCalculator.Application.Queries.CalculateCompoundInterest;

namespace CompoundInterestCalculator.Api.CalculateCompoundInterest;

public sealed class CalculateCompoundInterestInput : ICalculateCompoundInterestInput
{
    public int Period { get; set; }

    public decimal? InitialContribution { get; set; }

    public decimal? MonthlyValue { get; set; }

    public decimal InterestPercentage { get; set; }

    public int PeriodType { get; set; }

    public int InterestType { get; set; }
}