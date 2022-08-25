using CompoundInterestCalculator.Domain.Models;
using CompoundInterestCalculator.Domain.Models.IncomeTaxCalculator;

namespace CompoundInterestCalculator.Domain.Calculators;

public abstract class IncomeTaxCalculator : IIncomeTaxCalculator
{
    private readonly decimal IncomeTaxRate;

    public IncomeTaxCalculator(decimal incomeTaxRate)
    {
        IncomeTaxRate = incomeTaxRate;
    }

    public abstract bool Compatible(IncomeTaxPeriod incomeTaxPeriod);

    public IIncomeTaxCalculatorOutput Calculate(IIncomeTaxCalculatorInput input, CancellationToken cancellationToken)
    {
        var incomeTax = (input.TotalInterest * (this.IncomeTaxRate / 100));

        return new IncomeTaxCalculatorOutput
        {
            FinalTotalValue = input.TotalWithInterest,
            TotalAmountInvested = input.TotalInvested,
            TotalInInterest = input.TotalInterest,
            NetAmount = (input.TotalWithInterest - incomeTax).RoundWithTwoDigits()
        };
    }
}

public class IncomeTaxCalculatorTo180Days : IncomeTaxCalculator
{
    public IncomeTaxCalculatorTo180Days() : base(22.5m) {}
    public override bool Compatible(IncomeTaxPeriod incomeTaxPeriod) => incomeTaxPeriod == IncomeTaxPeriod.To180Days;
}

public class IncomeTaxCalculatorTo360Days : IncomeTaxCalculator
{
    public IncomeTaxCalculatorTo360Days() : base(20m) { }
    public override bool Compatible(IncomeTaxPeriod incomeTaxPeriod) => incomeTaxPeriod == IncomeTaxPeriod.To360Days;
}

public class IncomeTaxCalculatorTo720Days : IncomeTaxCalculator
{
    public IncomeTaxCalculatorTo720Days() : base(17.5m) { }
    public override bool Compatible(IncomeTaxPeriod incomeTaxPeriod) => incomeTaxPeriod == IncomeTaxPeriod.To720Days;
}

public class IncomeTaxCalculatorOver720Days : IncomeTaxCalculator
{
    public IncomeTaxCalculatorOver720Days() : base(15m) { }
    public override bool Compatible(IncomeTaxPeriod incomeTaxPeriod) => incomeTaxPeriod == IncomeTaxPeriod.Over720Days;
}