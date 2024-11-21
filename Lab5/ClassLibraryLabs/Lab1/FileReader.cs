namespace ClassLibraryLabs.Lab1;

public class FileReader
{
    public static (int Sum, int DigitsCount) ReadNumbersFromFile(string inputText)
    {
        var input = inputText.Split('\n');
        // Ensure the file contains exactly one line
        if (input.Length != 1)
        {
            throw new FileInputException("The file must contain exactly one line.");
        }

        // Split the line into parts and validate
        var parts = input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
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
}