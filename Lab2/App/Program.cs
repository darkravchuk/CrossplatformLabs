using App;

class Program
{
    static void Main()
    {
        try
        {
            var (N, coins, K, sums) = FileProcessor.ReadFromFile();

            var result = MoneyChangeCalculator.CalculateChange(coins, sums);

            FileProcessor.WriteToFile(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}