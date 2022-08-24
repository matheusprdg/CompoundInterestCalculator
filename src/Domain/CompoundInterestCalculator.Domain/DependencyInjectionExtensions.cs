using CompoundInterestCalculator.Domain.Calculators;
using CompoundInterestCalculator.Domain.Factories;
using CompoundInterestCalculator.Domain.Services.CalculateCompoundInterest;
using Microsoft.Extensions.DependencyInjection;

namespace CompoundInterestCalculator.Domain;
public static class DependencyInjectionExtensions
{
    public static void AddDomain(this IServiceCollection services)
    {
        services.AddTransient<ICalculateCompoundInterestService, CalculateCompoundInterestService>();
        services.AddSingleton<ICompoundInterestCalculator, CompoundInterestCalculator.Domain.Calculators.CompoundInterestCalculator>();
        services.AddSingleton<ICompoundInterestCalculationDetailFactory, CompoundInterestCalculationDetailFactory>();
    }
}