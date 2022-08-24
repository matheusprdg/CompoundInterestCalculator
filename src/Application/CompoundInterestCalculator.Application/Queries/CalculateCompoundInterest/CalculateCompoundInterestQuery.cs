using CompoundInterestCalculator.Domain.Models;
using CompoundInterestCalculator.Domain.Services.CalculateCompoundInterest;
using FluentValidation;

namespace CompoundInterestCalculator.Application.Queries.CalculateCompoundInterest;

public class CalculateCompoundInterestQuery : ICalculateCompoundInterestQuery
{
    private readonly ICalculateCompoundInterestService service;
    private readonly CalculateCompoundInterestInputValidator validator;

    public CalculateCompoundInterestQuery(ICalculateCompoundInterestService service)
    {
        this.service = service;
        this.validator = new CalculateCompoundInterestInputValidator();
    }

    public ICalculateCompoundInterestOutput Execute(ICalculateCompoundInterestInput input, CancellationToken cancellationToken)
    {
        this.validator.ValidateAndThrow(input);

        var retorno = this.service.Execute(new CompoundInterestCalculatorInput()
        {
            Period = input.Period,
            InitialContribution = input.InitialContribution,
            MonthlyValue = input.MonthlyValue,
            InterestPercentage = input.InterestPercentage,
            PeriodType = (PeriodType)input.PeriodType,
            InterestType = (InterestType)input.InterestType
        }, cancellationToken);

        return new CalculateCompoundInterestOutput(retorno);
    }

    private class CompoundInterestCalculatorInput : ICompoundInterestCalculatorInput
    {
        public int Period { get; set; }
        public decimal? InitialContribution { get; set; }
        public decimal? MonthlyValue { get; set; }
        public decimal InterestPercentage { get; set; }
        public PeriodType PeriodType { get; set; }
        public InterestType InterestType { get; set; }
    }
}