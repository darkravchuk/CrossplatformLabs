using System.Numerics;

namespace ClassLibraryLabs;

public static class Lab1
{
    public static void Execute(string inputFile, string outputFile)
    {
        int x;
        int k;
        BigInteger resultCount = 0;

        try
        {
            // Read numbers from file and calculate result
            (x, k) = FileReader.ReadNumbersFromFile(inputFile);
            resultCount = MoneyDistributor.CountWays(x, k);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occurred: {e.Message}");
            return;
        }

        // Try to write result to file
        try
        {
            FileReader.WriteResultToFile(resultCount, outputFile);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occurred while writing to file: {e.Message}");
        }
    }
    
    private static class MoneyDistributor
    {
        private const int BillDenomination = 5;
        private const int MaxMoneyAmount = 500;
        private const int MinMoneyAmount = 0;
        private const int MaxParticipants = 100;
        private const int MinParticipants = 0;

        public static BigInteger CountWays(int moneyAmount, int kids)
        {
            if (moneyAmount < MinMoneyAmount || moneyAmount > MaxMoneyAmount)
                throw new ArgumentException($"The money amount must be between {MinMoneyAmount} and {MaxMoneyAmount}.");
            if (kids < MinParticipants || kids > MaxParticipants)
                throw new ArgumentException($"The number of participants must be between {MinParticipants} and {MaxParticipants}.");
        
            int banknotes = CountBanknotes(moneyAmount);
            int participants = kids + 1;

            return CombinationCalculator.Comb(banknotes + participants - 1, participants - 1);
        }

        private static int CountBanknotes(int moneyAmount)
        {
            if (moneyAmount % BillDenomination != 0)
                throw new ArgumentException($"The money amount must be divisible by {BillDenomination}.", nameof(moneyAmount));

            return moneyAmount / BillDenomination;
        }
    }
    
    private static class CombinationCalculator
    {
        public static BigInteger Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("The factorial input must be non-negative.", nameof(n));
        
            BigInteger result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
        
            return result;
        }

        public static BigInteger Comb(int n, int k)
        {
            if (n < 0 || k < 0)
                throw new ArgumentException("Both parameters must be non-negative.");
            if (k > n)
                throw new ArgumentException("The second parameter must not exceed the first one.");
        
            BigInteger numerator = Factorial(n);
            BigInteger denominator = Factorial(k) * Factorial(n - k);
        
            return numerator / denominator;
        }
    }

    private class FileReader
    {
        private const string InputFileName = "INPUT.TXT";
        private const string OutputFileName = "OUTPUT.TXT";

        public static (int Sum, int DigitsCount) ReadNumbersFromFile(string inputFilePath)
        {
            // Check if the file exists
            if (!File.Exists(inputFilePath))
            {
                throw new FileInputException($"File {InputFileName} not found.");
            }

            // Read all lines and filter non-empty lines
            var lines = File.ReadAllLines(inputFilePath)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Trim())
                .ToArray();

            // Ensure the file contains exactly one line
            if (lines.Length != 1)
            {
                throw new FileInputException("The file must contain exactly one line.");
            }

            // Split the line into parts and validate
            var parts = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2)
            {
                throw new FileInputException("The line must contain exactly two space-separated integers.");
            }

            // Parse integers and handle errors
            if (!int.TryParse(parts[0], out var sum))
            {
                throw new FileInputException("The first value must be an integer.");
            }

            if (!int.TryParse(parts[1], out var digitsCount))
            {
                throw new FileInputException("The second value must be an integer.");
            }

            return (sum, digitsCount);
        }

        public static void WriteResultToFile(BigInteger result, string outputFilePath)
        {
            File.WriteAllText(outputFilePath, result.ToString());
        }
    }
}
