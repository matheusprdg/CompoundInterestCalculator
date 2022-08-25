namespace CompoundInterestCalculator.Domain.Models.IncomeTaxCalculator;

public interface IIncomeTaxCalculatorOutput
{
    decimal FinalTotalValue { get; set; }
    decimal TotalAmountInvested { get; set; }
    decimal TotalInInterest { get; set; }
    decimal NetAmount { get; set; }
}