namespace CompoundInterestCalculator.Domain;

public static class CompoundInterestCalculatorExtensions
{
    public static decimal RoundWithTwoDigits(this decimal number)
    {
        return Math.Round(number, 2, MidpointRounding.AwayFromZero);
    }
}