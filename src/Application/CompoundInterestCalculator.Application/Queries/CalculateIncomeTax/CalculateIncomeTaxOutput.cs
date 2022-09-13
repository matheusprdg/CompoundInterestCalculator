using CompoundInterestCalculator.Domain.Models.IncomeTaxCalculator;

namespace CompoundInterestCalculator.Application.Queries.CalculateIncomeTax;

public sealed class CalculateIncomeTaxOutput : ICalculateIncomeTaxOutput
{
    private readonly IIncomeTaxCalculatorOutput output;

    public CalculateIncomeTaxOutput(IIncomeTaxCalculatorOutput output)
    {
        this.output = output;
    }

    public decimal FinalTotalValue => this.output.FinalTotalValue;
    public decimal TotalAmountInvested => this.output.TotalAmountInvested;
    public decimal TotalInInterest => this.output.TotalInInterest;
    public decimal NetAmount => this.output.NetAmount;
}