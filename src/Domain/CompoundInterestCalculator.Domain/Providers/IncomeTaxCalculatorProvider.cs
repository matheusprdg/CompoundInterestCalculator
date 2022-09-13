using CompoundInterestCalculator.Domain.Calculators;

namespace CompoundInterestCalculator.Domain.Providers;

public sealed class IncomeTaxCalculatorProvider : IIncomeTaxCalculatorProvider
{
    private readonly IEnumerable<IIncomeTaxCalculator> calculators;

    public IncomeTaxCalculatorProvider(IEnumerable<IIncomeTaxCalculator> calculators)
    {
        this.calculators = calculators;
    }

    public IIncomeTaxCalculator Get(Models.IncomeTaxPeriod incomeTaxPeriod)
    {
        return this.calculators.FirstOrDefault(f => f.Compatible(incomeTaxPeriod))!;
    }
}
