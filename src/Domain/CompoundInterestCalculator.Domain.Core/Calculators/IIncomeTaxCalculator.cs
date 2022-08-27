using CompoundInterestCalculator.Domain.Models;
using CompoundInterestCalculator.Domain.Models.IncomeTaxCalculator;

namespace CompoundInterestCalculator.Domain.Calculators;

public interface IIncomeTaxCalculator
{
    bool Compatible(IncomeTaxPeriod incomeTaxPeriod);
    IIncomeTaxCalculatorOutput Calculate(IIncomeTaxCalculatorInput input, CancellationToken cancellationToken);
}