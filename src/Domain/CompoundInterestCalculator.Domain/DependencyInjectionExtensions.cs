using CompoundInterestCalculator.Domain.Calculator.CompoundInterest;
using CompoundInterestCalculator.Domain.Services.CalculateCompoundInterest;
using Microsoft.Extensions.DependencyInjection;

namespace CompoundInterestCalculator.Domain;
public static class DependencyInjectionExtensions
{
    public static void AddDomain(this IServiceCollection services)
    {
        services.AddTransient<ICalculateCompoundInterestService, CalculateCompoundInterestService>();
        services.AddSingleton<ICompoundInterestCalculator, CompoundInterestCalculator.Domain.Calculator.CompoundInterest.CompoundInterestCalculator>();
    }
}