namespace ClassLibraryLabs.Lab3;

public static class Lab3
{
    public static void Execute(string inputText, out string outputResult)
    {
        try
        {
            var (N, M, roads) = RoadPlanProcessor.ReadFromFile(inputText);

            int K = WeaklyConnectedSolver.Solve(N, roads);

            // Convert the result to a space-separated string for displaying in a textarea
            outputResult = string.Join(" ", K);
        }
        catch (Exception ex)
        {
            outputResult = $"Exception: {ex.Message}";
        }
    }
}