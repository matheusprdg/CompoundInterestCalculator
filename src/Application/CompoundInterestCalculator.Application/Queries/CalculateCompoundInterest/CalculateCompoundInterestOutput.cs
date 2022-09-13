using CompoundInterestCalculator.Domain.Models.CompoundInterestCalculator;

namespace CompoundInterestCalculator.Application.Queries.CalculateCompoundInterest;

public sealed class CalculateCompoundInterestOutput : ICalculateCompoundInterestOutput
{
    private readonly ICompoundInterestCalculatorOutput output;

    public CalculateCompoundInterestOutput(ICompoundInterestCalculatorOutput output)
    {
        this.output = output;
    }

    public decimal FinalTotalValue => this.output.FinalTotalValue;
    public decimal TotalAmountInvested => this.output.TotalAmountInvested;
    public decimal TotalInInterest => this.output.TotalInInterest;
    public IEnumerable<ICalculateCompoundInterestCalculationDetail> Details => this.FillDetails();

    private IEnumerable<ICalculateCompoundInterestCalculationDetail> FillDetails()
    {
        foreach (var detail in this.output.Details)
        {
            yield return new CalculateCompoundInterestCalculationDetail(
                detail.Month,
                detail.Interest,
                detail.TotalInvested,
                detail.TotalInterest,
                detail.AccumulatedTotal,
                detail.InitialContribution);
        }
    }
}