namespace TaxCalculator.ConsoleApp.IO.Interfaces
{
    public interface IInputOutputHandler
    {
        void StartMessage();

        string InAmount();

        void Out(string outMessage);
    }
}
