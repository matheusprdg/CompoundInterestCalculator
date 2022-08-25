using CompoundInterestCalculator.Domain.Models.CompoundInterestCalculator;

namespace CompoundInterestCalculator.Domain.Calculators;

public interface ICompoundInterestCalculator
{
    ICompoundInterestCalculatorOutput Calculate(ICompoundInterestCalculatorInput input, CancellationToken cancellationToken);
}