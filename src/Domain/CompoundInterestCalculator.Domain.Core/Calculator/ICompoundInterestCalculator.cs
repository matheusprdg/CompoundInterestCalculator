using CompoundInterestCalculator.Domain.Models;

namespace CompoundInterestCalculator.Domain.Calculator.CompoundInterest;

public interface ICompoundInterestCalculator
{
    ICompoundInterestCalculatorOutput CalculateCompoundInterest(ICompoundInterestCalculatorInput input);
}