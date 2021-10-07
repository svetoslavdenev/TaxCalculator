namespace TaxCalculator.ConsoleApp
{
    using System;

    using Microsoft.Extensions.DependencyInjection;
    using TaxCalculator.ConsoleApp.IO;
    using TaxCalculator.ConsoleApp.IO.Interfaces;
    using TaxCalculator.ConsoleApp.Services;
    using TaxCalculator.ConsoleApp.Services.Interfaces;
    using TaxCalculator.Core.IoC;

    public static class App
    {
        public static void Run()
        {
            var dependencies = SetUpDependencies();

            var ioHandler = dependencies.GetService<IInputOutputHandler>();
            var calculator = dependencies.GetService<ISalaryCalculator>();

            ioHandler.StartMessage();

            while (true)
            {
                var input = ioHandler.InAmount();

                if (IsEndCommand(input))
                {
                    return;
                }

                var (isValidamount, amount) = IsValidAmount(input);
                if (!isValidamount)
                {
                    ioHandler.Out($"Provided input:{input} is not a valid amount. Try again.");
                    continue;
                }

                if (amount <= 0)
                {
                    ioHandler.Out($"Please provide amount greater then zero");
                    continue;
                }

                var salary = calculator.CalculateSalary(amount);

                ioHandler.Out(salary.ToString());
            }
        }

        private static ServiceProvider SetUpDependencies()
        {
            return new ServiceCollection()
                .AddTaxCalculation()
                .AddSingleton<ISalaryCalculator, SalaryCalculator>()
                .AddSingleton<IInputOutputHandler, ConsoleHandler>()
                .BuildServiceProvider();
        }

        private static (bool, decimal) IsValidAmount(string input)
        {
            try
            {
                return (true, decimal.Parse(input.Trim()));
            }
            catch (Exception)
            {
                return (false, 0);
            }
        }

        private static bool IsEndCommand(string command)
        {
            return command.Trim().ToLower() == "end";
        }
    }
}
