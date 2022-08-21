using CompoundInterestCalculator.Application.Queries.CalculateCompoundInterest;
using Microsoft.Extensions.DependencyInjection;

namespace CompoundInterestCalculator.Application;

public static class DependencyInjectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddTransient<ICalculateCompoundInterestQuery, CalculateCompoundInterestQuery>();
    }
}