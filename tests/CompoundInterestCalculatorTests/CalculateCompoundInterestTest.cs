using CompoundInterestCalculator.Application.Queries.CalculateCompoundInterest;
using CompoundInterestCalculator.Domain.Calculators;
using CompoundInterestCalculator.Domain.Factories;
using CompoundInterestCalculator.Domain.Services.CalculateCompoundInterest;
using Microsoft.Extensions.DependencyInjection;

namespace CompoundInterestCalculatorTests
{
    public class CalculateCompoundInterestTest
    {
        private readonly ICalculateCompoundInterestQuery query;

        public CalculateCompoundInterestTest()
        {
            var services = new ServiceCollection();
            services.AddTransient<ICalculateCompoundInterestQuery, CalculateCompoundInterestQuery>();
            services.AddTransient<ICalculateCompoundInterestService, CalculateCompoundInterestService>();
            services.AddTransient<ICompoundInterestCalculator, CompoundInterestCalculator.Domain.Calculators.CompoundInterestCalculator>();
            services.AddTransient<ICompoundInterestCalculationDetailFactory, CompoundInterestCalculationDetailFactory>();

            var serviceProvider = services.BuildServiceProvider();
            this.query = serviceProvider.GetService<ICalculateCompoundInterestQuery>();
        }

        [Fact]
        public void CalculateCompoundInterestTestMustBeDoneWithSuccess()
        {
            var input = new Input
            {
                Period = 12,
                InitialContribution = 1000,
                MonthlyValue = 1000,
                InterestPercentage = 1,
                InterestType = 2,
                PeriodType = 2
            };

            var items = this.query.Execute(input, CancellationToken.None);
            Assert.NotNull(items);
        }


    }

    public class Input : ICalculateCompoundInterestInput
    {
        public int Period { get; set; }

        public decimal? InitialContribution { get; set; }

        public decimal? MonthlyValue { get; set; }

        public decimal InterestPercentage { get; set; }

        public int PeriodType { get; set; }

        public int InterestType { get; set; }
    }
}