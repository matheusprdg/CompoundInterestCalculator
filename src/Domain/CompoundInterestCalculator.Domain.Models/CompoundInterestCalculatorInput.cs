namespace CompoundInterestCalculator.Domain.Models;

public class CompoundInterestCalculatorInput : ICompoundInterestCalculatorInput
{
    public int Period { get; set; }
    public decimal InitialContribution { get; set; }
    public decimal MonthlyValue { get; set; }
    public decimal InterestPercentage { get; set; }
    public PeriodType PeriodType { get; set; }
    public InterestType InterestType { get; set; }
}