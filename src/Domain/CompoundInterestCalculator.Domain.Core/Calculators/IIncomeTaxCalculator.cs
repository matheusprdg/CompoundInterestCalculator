using CompoundInterestCalculator.Domain.Models.IncomeTaxCalculator;

namespace CompoundInterestCalculator.Domain.Calculators;

public interface IIncomeTaxCalculator
{
    IIncomeTaxCalculatorOutput Calculate(IIncomeTaxCalculatorInput input, CancellationToken cancellationToken);
}