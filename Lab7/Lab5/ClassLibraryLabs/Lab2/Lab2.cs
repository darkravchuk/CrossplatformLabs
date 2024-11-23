namespace ClassLibraryLabs.Lab2;

public class Lab2
{
    public static void Execute(string inputText, out string outputResult)
    {
        try
        {
            var (N, coins, K, sums) = FileProcessor.ReadFromText(inputText);

            var result = MoneyChangeCalculator.CalculateChange(coins, sums);

            // Convert the result to a space-separated string for displaying in a textarea
            outputResult = string.Join(" ", result);
        }
        catch (Exception ex)
        {
            outputResult = $"Exception: {ex.Message}";
        }
    }
}
