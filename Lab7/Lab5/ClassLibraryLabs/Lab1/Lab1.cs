using System.Numerics;

namespace ClassLibraryLabs.Lab1;

public static class Lab1
{
    public static void Execute(string inputText, out string outputResult)
    {
        int x;
        int k;
        BigInteger resultCount = 0;

        try
        {
            // Read numbers from file and calculate result
            (x, k) = FileReader.ReadNumbersFromFile(inputText);
            resultCount = MoneyDistributor.CountWays(x, k);
            outputResult = string.Join(" ", resultCount);
        }
        catch (Exception e)
        {
            outputResult = $"Exception: {e.Message}";
        }
    }
}