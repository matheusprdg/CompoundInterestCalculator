using CompoundInterestCalculator.Domain.Models.IncomeTaxCalculator;
using CompoundInterestCalculator.Domain.Providers;

namespace CompoundInterestCalculator.Domain.Services.CalculateIncomeTaxService;

public class CalculateIncomeTaxService : ICalculateIncomeTaxService
{
    private readonly IIncomeTaxCalculatorProvider provider;

    public CalculateIncomeTaxService(IIncomeTaxCalculatorProvider provider)
    {
        this.provider = provider;
    }

    public IIncomeTaxCalculatorOutput Execute(IIncomeTaxCalculatorInput input, CancellationToken cancellationToken)
    {
        var calculator = this.provider.Get(input.IncomeTaxPeriod);

        return calculator.Calculate(input, cancellationToken);
    }
}