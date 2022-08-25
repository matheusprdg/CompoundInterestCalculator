using CompoundInterestCalculator.Domain.Models.IncomeTaxCalculator;

namespace CompoundInterestCalculator.Domain.Services.CalculateIncomeTaxService;

public interface ICalculateIncomeTaxService
{
    IIncomeTaxCalculatorOutput Execute(IIncomeTaxCalculatorInput input, CancellationToken cancellationToken);
}