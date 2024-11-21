namespace ClassLibraryLabs.Lab2;

public static class Lab2
{
    public static void Execute(string inputFile, string outputFile)
    {
        try
        {
            var (N, coins, K, sums) = FileProcessor.ReadFromFile(inputFile);

            var result = MoneyChangeCalculator.CalculateChange(coins, sums);

            FileProcessor.WriteToFile(result, outputFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}