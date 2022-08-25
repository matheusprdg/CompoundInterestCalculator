using CompoundInterestCalculator.Domain.Calculators;
using CompoundInterestCalculator.Domain.Models;

namespace CompoundInterestCalculator.Domain.Providers;

public interface IIncomeTaxCalculatorProvider
{
    IIncomeTaxCalculator Get(IncomeTaxPeriod incomeTaxPeriod);
}
