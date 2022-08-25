using CompoundInterestCalculator.Domain.Models;
using CompoundInterestCalculator.Domain.Models.IncomeTaxCalculator;
using CompoundInterestCalculator.Domain.Services.CalculateIncomeTaxService;
using FluentValidation;

namespace CompoundInterestCalculator.Application.Queries.CalculateIncomeTax;

public class CalculateIncomeTaxQuery : ICalculateIncomeTaxQuery
{
    private readonly ICalculateIncomeTaxService service;
    private readonly CalculateIncomeTaxInputValidator inputValidator;

    public CalculateIncomeTaxQuery(ICalculateIncomeTaxService service)
    {
        this.service = service;
        this.inputValidator = new CalculateIncomeTaxInputValidator();
    }

    public ICalculateIncomeTaxOutput Execute(ICalculateIncomeTaxInput input, CancellationToken cancellationToken)
    {
        this.inputValidator.ValidateAndThrow(input);

        var retorno = this.service.Execute(
            new Input
            {
                TotalWithInterest = input.TotalWithInterest,
                TotalInterest = input.TotalInterest,
                TotalInvested = input.TotalInvested,
                IncomeTaxPeriod = (IncomeTaxPeriod)input.IncomeTaxPeriod
            }, 
            cancellationToken);

        return new CalculateIncomeTaxOutput(retorno);
    }

    private class Input : IIncomeTaxCalculatorInput
    {
        public decimal TotalWithInterest { get; set; }
        public decimal TotalInvested { get; set; }
        public decimal TotalInterest { get; set; }
        public IncomeTaxPeriod IncomeTaxPeriod { get; set; }
    }
}