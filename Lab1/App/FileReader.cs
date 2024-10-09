using System.Numerics;

namespace App;

public class FileReader
{
    private const string InputFileName = "INPUT.TXT";
    private const string OutputFileName = "OUTPUT.TXT";

    public static (int Sum, int DigitsCount) ReadNumbersFromFile()
    {
        // Check if the file exists
        if (!File.Exists(InputFileName))
        {
            throw new FileInputException($"File {InputFileName} not found.");
        }

        // Read all lines and filter non-empty lines
        var lines = File.ReadAllLines(InputFileName)
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

    public static void WriteResultToFile(BigInteger result)
    {
        File.WriteAllText(OutputFileName, result.ToString());
    }
}