using CompoundInterestCalculator.Domain.Models;

namespace CompoundInterestCalculator.Application.Queries.CalculateCompoundInterest;

public class CalculateCompoundInterestOutput : ICalculateCompoundInterestOutput
{
    private readonly ICompoundInterestCalculatorOutput output;

    public CalculateCompoundInterestOutput(ICompoundInterestCalculatorOutput output)
    {
        this.output = output;
    }

    public decimal FinalTotalValue => this.output.FinalTotalValue;
    public decimal TotalAmountInvested => this.output.TotalAmountInvested;
    public decimal TotalInInterest => this.output.TotalInInterest;
}