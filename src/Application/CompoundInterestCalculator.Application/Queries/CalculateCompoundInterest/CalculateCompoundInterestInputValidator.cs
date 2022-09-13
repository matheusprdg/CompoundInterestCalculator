using CompoundInterestCalculator.Domain.Models;
using FluentValidation;

namespace CompoundInterestCalculator.Application.Queries.CalculateCompoundInterest;

public sealed class CalculateCompoundInterestInputValidator : AbstractValidator<ICalculateCompoundInterestInput>
{
	public CalculateCompoundInterestInputValidator()
	{
		RuleFor(f => f)
			.NotNull()
			.Custom((f, context) => this.ValidateValues(f, context))
            .Custom((f, context) => this.ValidateTypes(f, context));

		RuleFor(f => f.InterestPercentage)
			.NotNull()
			.GreaterThan(0)
			.WithMessage("Porcentagem n�o pode ser menor ou igual a 0.");

		RuleFor(f => f.Period)
			.NotNull()
			.GreaterThan(0)
			.WithMessage("Per�odo n�o pode ser menor ou igual a 0.");
	}

	private void ValidateValues(ICalculateCompoundInterestInput input, ValidationContext<ICalculateCompoundInterestInput> context)
	{
		if (!input.MonthlyValue.HasValue && !input.InitialContribution.HasValue)
		{
			context.AddFailure("� necess�rio informar um valor inicial ou valor mensal.");
		}
	}

    private void ValidateTypes(ICalculateCompoundInterestInput input, ValidationContext<ICalculateCompoundInterestInput> context)
    {
		if (!Enum.IsDefined(typeof(InterestType), input.InterestType))
		{
			context.AddFailure("Tipo da taxa de juros (anual, mensal) n�o existe. Informe um tipo de taxa v�lido.");
		}

        if (!Enum.IsDefined(typeof(PeriodType), input.PeriodType))
		{
            context.AddFailure("Tipo do per�odo (anual, mensal) n�o existe. Informe um tipo de per�odo v�lido.");
        }
    }
}