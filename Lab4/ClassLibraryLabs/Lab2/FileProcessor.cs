namespace ClassLibraryLabs.Lab2;

public class FileProcessor
{
    private const string InputFileName = "INPUT.TXT";
    private const string OutputFileName = "OUTPUT.TXT";
    private const int MaxValue = 1000;  // Maximum allowed value for all numbers

    public static (int N, int[] Coins, int K, int[] Sums) ReadFromFile(string inputFile)
    {
        var input = File.ReadAllLines(inputFile);

        // Check number of lines
        if (input.Length != 4)
        {
            throw new InvalidDataException("The file must contain exactly 4 lines.");
        }

        // Read and validate the first line (number of coin types)
        int N = int.Parse(input[0]);
        if (N < 1 || N > MaxValue)
        {
            throw new InvalidDataException($"The number of coin types must be a natural number between 1 and {MaxValue}.");
        }

        // Read and validate the second line (coin denominations)
        var coins = Array.ConvertAll(input[1].Split(), int.Parse);
        if (coins.Length != N)
        {
            throw new InvalidDataException($"The number of coin denominations must match the number {N} from the first line.");
        }
        if (coins.Any(coin => coin < 1 || coin > MaxValue))
        {
            throw new InvalidDataException($"Coin denominations must be natural numbers that do not exceed {MaxValue}.");
        }

        // Read and validate the third line (number of sums)
        int K = int.Parse(input[2]);
        if (K < 1 || K > MaxValue)
        {
            throw new InvalidDataException($"The number of requested sums must be a natural number between 1 and {MaxValue}.");
        }

        // Read and validate the fourth line (requested sums)
        var sums = Array.ConvertAll(input[3].Split(), int.Parse);
        if (sums.Length != K)
        {
            throw new InvalidDataException($"The number of requested sums must match the number {K} from the third line.");
        }
        if (sums.Any(sum => sum < 1 || sum > MaxValue))
        {
            throw new InvalidDataException($"Requested sums must be natural numbers that do not exceed {MaxValue}.");
        }

        return (N, coins, K, sums);
    }

    public static void WriteToFile(int[] result, string outputFile)
    {
        File.WriteAllText(outputFile, string.Join(" ", result));
    }
}