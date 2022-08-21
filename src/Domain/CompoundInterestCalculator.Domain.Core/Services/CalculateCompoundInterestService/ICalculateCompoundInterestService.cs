using CompoundInterestCalculator.Domain.Models;

namespace CompoundInterestCalculator.Domain.Services.CalculateCompoundInterest;

public interface ICalculateCompoundInterestService
{
    ICompoundInterestCalculatorOutput Execute(ICompoundInterestCalculatorInput input);
}