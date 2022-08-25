using CompoundInterestCalculator.Domain.Models;
using FluentValidation;

namespace CompoundInterestCalculator.Application.Queries.CalculateIncomeTax;

public class CalculateIncomeTaxInputValidator : AbstractValidator<ICalculateIncomeTaxInput>
{
	public CalculateIncomeTaxInputValidator()
	{
		RuleFor(f => f)
			.NotNull()
            .Custom((f, context) => this.ValidateTypes(f, context));

		RuleFor(f => f.TotalInvested)
			.NotNull()
			.GreaterThan(0)
			.WithMessage("Total investido deve ser maior que 0.");

		RuleFor(f => f.TotalWithInterest)
			.NotNull()
			.GreaterThan(0)
			.WithMessage("Total acumulado deve ser maior que 0.");

		RuleFor(f => f.TotalInterest)
			.NotNull()
			.GreaterThan(0)
			.WithMessage("Total de juros deve ser maior que 0.");
	}

    private void ValidateTypes(ICalculateIncomeTaxInput input, ValidationContext<ICalculateIncomeTaxInput> context)
    {
		if (!Enum.IsDefined(typeof(IncomeTaxPeriod), input.IncomeTaxPeriod))
		{
			context.AddFailure("Intervalo de desconto do I.R. não existe. Informe um intervalo válido.");
		}
    }
}