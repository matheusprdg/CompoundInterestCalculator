namespace CompoundInterestCalculator.Application.Queries.CalculateCompoundInterest;

public interface ICalculateCompoundInterestInput
{
    int Period { get; }
    decimal? InitialContribution { get; }
    decimal? MonthlyValue { get; }
    decimal InterestPercentage { get; }
    int PeriodType { get; }
    int InterestType { get; }
}