namespace CompoundInterestCalculator.Application.Queries.CalculateIncomeTax;

public interface ICalculateIncomeTaxQuery
{
    ICalculateIncomeTaxOutput Execute(ICalculateIncomeTaxInput input, CancellationToken cancellationToken);
}