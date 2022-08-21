namespace CompoundInterestCalculator.Application.Queries.CalculateCompoundInterest;

public interface ICalculateCompoundInterestQuery
{
    Task<ICalculateCompoundInterestOutput> Execute(ICalculateCompoundInterestInput input);
}