using CompoundInterestCalculator.Application.Queries.CalculateCompoundInterest;
using CompoundInterestCalculator.Application.Queries.CalculateIncomeTax;
using CompoundInterestCalculator.Domain.Calculators;
using CompoundInterestCalculator.Domain.Factories;
using CompoundInterestCalculator.Domain.Providers;
using CompoundInterestCalculator.Domain.Services.CalculateCompoundInterest;
using CompoundInterestCalculator.Domain.Services.CalculateIncomeTaxService;
using Microsoft.Extensions.DependencyInjection;

namespace CompoundInterestCalculator.CrossCutting.IoC;

public static class DependencyInjectionExtensions
{
    public static void Register(this IServiceCollection services)
    {
        services.AddTransient<ICalculateCompoundInterestService, CalculateCompoundInterestService>();
        services.AddTransient<ICalculateIncomeTaxService, CalculateIncomeTaxService>();
        services.AddSingleton<IIncomeTaxCalculatorProvider, IncomeTaxCalculatorProvider>();
        services.AddSingleton<ICompoundInterestCalculator, CompoundInterestCalculator.Domain.Calculators.CompoundInterestCalculator>();
        services.AddSingleton<IIncomeTaxCalculator, IncomeTaxCalculatorTo180Days>();
        services.AddSingleton<IIncomeTaxCalculator, IncomeTaxCalculatorTo360Days>();
        services.AddSingleton<IIncomeTaxCalculator, IncomeTaxCalculatorTo720Days>();
        services.AddSingleton<IIncomeTaxCalculator, IncomeTaxCalculatorOver720Days>();

        services.AddSingleton<ICompoundInterestCalculationDetailFactory, CompoundInterestCalculationDetailFactory>();

        services.AddTransient<ICalculateCompoundInterestQuery, CalculateCompoundInterestQuery>();
        services.AddTransient<ICalculateIncomeTaxQuery, CalculateIncomeTaxQuery>();
    }
}