using System.Numerics;
using System.Text;

namespace App;

static class Program
{
    static void Main(string[] args)
    {
        int x;
        int k;
        BigInteger resultCount = 0;

        try
        {
            // Read numbers from file and calculate result
            (x, k) = FileReader.ReadNumbersFromFile();
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
            FileReader.WriteResultToFile(resultCount);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occurred while writing to file: {e.Message}");
        }
    }
}