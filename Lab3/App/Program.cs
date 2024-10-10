using App;

class Program
{
    const int INF = 1000000000; // Большое число для обозначения бесконечности

    static void Main(string[] args)
    {
        try
        {
            var (N, M, roads) = RoadPlanProcessor.ReadFromFile();

            int K = WeaklyConnectedSolver.Solve(N, roads);

            RoadPlanProcessor.WriteToFile(K);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}
