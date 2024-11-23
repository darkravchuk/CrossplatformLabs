namespace ClassLibraryLabs.Lab2;

 public class FileProcessor
{
    private const int MaxValue = 1000;  // Maximum allowed value for all numbers

    public static (int N, int[] Coins, int K, int[] Sums) ReadFromText(string inputText)
    {
        // Split the input text by lines (newlines)
        var input = inputText.Split('\n');

        // Process each line similar to before
        if (input.Length != 4)
        {
            throw new InvalidDataException("The input must contain exactly 4 lines.");
        }

        // Read and validate the first line (number of coin types)
        int N = int.Parse(input[0].Trim());
        if (N < 1 || N > MaxValue)
        {
            throw new InvalidDataException($"The number of coin types must be a natural number between 1 and {MaxValue}.");
        }

        // Read and validate the second line (coin denominations)
        var coins = Array.ConvertAll(input[1].Trim().Split(), int.Parse);
        if (coins.Length != N)
        {
            throw new InvalidDataException($"The number of coin denominations must match the number {N} from the first line.");
        }
        if (coins.Any(coin => coin < 1 || coin > MaxValue))
        {
            throw new InvalidDataException($"Coin denominations must be natural numbers that do not exceed {MaxValue}.");
        }

        // Read and validate the third line (number of sums)
        int K = int.Parse(input[2].Trim());
        if (K < 1 || K > MaxValue)
        {
            throw new InvalidDataException($"The number of requested sums must be a natural number between 1 and {MaxValue}.");
        }

        // Read and validate the fourth line (requested sums)
        var sums = Array.ConvertAll(input[3].Trim().Split(), int.Parse);
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
}