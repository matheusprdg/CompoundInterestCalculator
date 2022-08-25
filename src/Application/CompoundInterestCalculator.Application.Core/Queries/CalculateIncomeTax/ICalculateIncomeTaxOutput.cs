namespace CompoundInterestCalculator.Application.Queries.CalculateIncomeTax;

public interface ICalculateIncomeTaxOutput
{
    decimal FinalTotalValue { get; }
    decimal TotalAmountInvested { get; }
    decimal TotalInInterest { get; }
    decimal NetAmount { get; }
}