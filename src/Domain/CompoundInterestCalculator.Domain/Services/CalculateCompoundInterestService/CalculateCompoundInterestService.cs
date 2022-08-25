using CompoundInterestCalculator.Domain.Calculators;
using CompoundInterestCalculator.Domain.Models.CompoundInterestCalculator;

namespace CompoundInterestCalculator.Domain.Services.CalculateCompoundInterest;

public class CalculateCompoundInterestService : ICalculateCompoundInterestService
{
    private readonly ICompoundInterestCalculator calculator;

    public CalculateCompoundInterestService(ICompoundInterestCalculator calculator)
    {
        this.calculator = calculator;
    }

    public ICompoundInterestCalculatorOutput Execute(ICompoundInterestCalculatorInput input, CancellationToken cancellationToken)
    {
        return this.calculator.Calculate(input, cancellationToken);
    }
}