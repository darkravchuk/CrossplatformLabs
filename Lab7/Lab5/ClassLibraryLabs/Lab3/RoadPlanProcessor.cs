namespace ClassLibraryLabs.Lab3;

public static class RoadPlanProcessor
{
    private const int MinCities = 2;   // Minimum number of cities
    private const int MaxCities = 300; // Maximum number of cities
    private const int MinRoads = 1;    // Minimum number of roads
    private const int MaxRoads = 105000; // Maximum number of roads

    public static (int N, int M, (int Start, int End)[] Roads) ReadFromFile(string inputText)
    {
        var input = inputText.Replace("\r", "").Split('\n');

        // Reading the first line containing the number of cities and roads
        var firstLine = input[0].Split(" ");
        Console.WriteLine(firstLine.Length);
        if (firstLine.Length != 2)
        {
            throw new InvalidDataException("The first line must contain two numbers: number of cities and number of roads.");
        }

        // Parsing the number of cities and roads
        int N = int.Parse(firstLine[0]);
        int M = int.Parse(firstLine[1]);

        // Validating that the number of cities and roads are within the allowed range
        if (N < MinCities || N > MaxCities)
        {
            throw new InvalidDataException($"The number of cities must be between {MinCities} and {MaxCities}.");
        }

        if (M < MinRoads || M > MaxRoads)
        {
            throw new InvalidDataException($"The number of roads must be between {MinRoads} and {MaxRoads}.");
        }

        // Check that the file contains the correct number of rows
        if (input.Length != M + 1)
        {
            throw new InvalidDataException($"Expected {M} roads, but found {input.Length - 1} road entries.");
        }
        
        // Reading the roads
        var roads = new (int Start, int End)[M];
        for (int i = 0; i < M; i++)
        {
            var road = input[i + 1].Split();
            if (road.Length != 2)
            {
                throw new InvalidDataException("Each road must be described by two numbers: start city and end city.");
            }

            int start = int.Parse(road[0]);
            int end = int.Parse(road[1]);

            // Validating that the city numbers are within the range [1, N]
            if (start < 1 || start > N || end < 1 || end > N)
            {
                throw new InvalidDataException($"City numbers must be natural numbers between 1 and {N}.");
            }

            // Important: converting to zero-based indexing for array usage
            roads[i] = (start - 1, end - 1);
        }

        return (N, M, roads);
    }
    
}