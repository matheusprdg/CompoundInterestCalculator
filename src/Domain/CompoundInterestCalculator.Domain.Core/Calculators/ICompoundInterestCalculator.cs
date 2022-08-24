using CompoundInterestCalculator.Domain.Models;

namespace CompoundInterestCalculator.Domain.Calculators;

public interface ICompoundInterestCalculator
{
    ICompoundInterestCalculatorOutput Calculate(ICompoundInterestCalculatorInput input, CancellationToken cancellationToken);
}