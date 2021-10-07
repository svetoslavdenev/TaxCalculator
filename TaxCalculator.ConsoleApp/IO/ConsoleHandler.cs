namespace TaxCalculator.ConsoleApp.IO
{
    using System;

    using TaxCalculator.ConsoleApp.IO.Interfaces;

    public class ConsoleHandler : IInputOutputHandler
    {
        public void StartMessage()
        {
            Console.WriteLine("Tax calculator for Imaginaria has started.");
        }

        public string InAmount()
        {
            Console.Write("Enter gross value and press enter (or end for ending the program): ");
            return Console.ReadLine();
        }

        public void Out(string outMessage)
        {
            Console.WriteLine(outMessage);
        }
    }
}
