namespace ClassLibraryLabs.Lab3;

public static class Lab3
{
    public static void Execute(string inputFile, string outputFile)
    {
        try
        {
            var (N, M, roads) = RoadPlanProcessor.ReadFromFile(inputFile);

            int K = WeaklyConnectedSolver.Solve(N, roads);

            RoadPlanProcessor.WriteToFile(K, outputFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}