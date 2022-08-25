namespace CompoundInterestCalculator.Application.Queries.CalculateIncomeTax;

public interface ICalculateIncomeTaxInput
{
    decimal TotalWithInterest { get; set; }
    decimal TotalInvested { get; set; }
    decimal TotalInterest { get; set; }
    int IncomeTaxPeriod { get; set; }
}