using System;
namespace CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ExternalCurrencyService();
            var converter = new CurrencyServiceAdapter(service);

            // Prompt the user to enter the amount to be converted
            Console.WriteLine("Please enter the amount in USD you want to convert to EUR:");
            string input = Console.ReadLine();

            try
            {
                // Attempt to parse the input to a double
                double amountToConvert = double.Parse(input);

                // Perform the conversion
                double convertedAmount = converter.Convert("USD", "EUR", amountToConvert);

                // Output the result
                Console.WriteLine($"{amountToConvert} USD is {convertedAmount} EUR.");
            }
            catch (FormatException)
            {
                Console.WriteLine("The amount entered is not a valid number.");
            }
            catch (Exception ex)
            {
                // Handle any other unexpected exceptions
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
