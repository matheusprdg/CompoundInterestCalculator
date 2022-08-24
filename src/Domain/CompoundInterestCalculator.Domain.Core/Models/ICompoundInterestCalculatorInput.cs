namespace CompoundInterestCalculator.Domain.Models;

public interface ICompoundInterestCalculatorInput
{
    int Period { get; set; }
    decimal? InitialContribution { get; set; }
    decimal? MonthlyValue { get; set; }
    decimal InterestPercentage { get; set; }
    PeriodType PeriodType { get; set; }
    InterestType InterestType { get; set; }
}