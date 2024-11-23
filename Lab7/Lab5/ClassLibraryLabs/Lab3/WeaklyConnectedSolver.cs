namespace ClassLibraryLabs.Lab3;

public static class WeaklyConnectedSolver
{
    private const int INF = 1000000000;

    public static int Solve(int N, (int Start, int End)[] roads)
    {
        if (roads == null || roads.Length == 0)
        {
            throw new ArgumentException("The roads array cannot be null or empty.");
        }

        foreach (var road in roads)
        {
            if (road.Start < 0 || road.Start >= N || road.End < 0 || road.End >= N)
            {
                throw new ArgumentOutOfRangeException($"Road contains invalid city index: ({road.Start}, {road.End})");
            }
        }
        
        int[,] dist = InitializeDistanceMatrix(N);
        AddRoadsToGraph(N, dist, roads);
        RunFloydWarshall(N, dist);
        return FindMaxK(N, dist);
    }

    // Initializes the distance matrix and checks the number of cities
    public static int[,] InitializeDistanceMatrix(int N)
    {
        if (N <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(N), "The number of cities must be a positive integer.");
        }

        int[,] dist = new int[N, N];
    
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                dist[i, j] = (i == j) ? 0 : INF;
            }
        }

        return dist;
    }

    // Adds roads to the graph based on the input and validates indices
    public static void AddRoadsToGraph(int N, int[,] dist, (int Start, int End)[] roads)
    {
        foreach (var road in roads)
        {
            if (road.Start < 0 || road.Start >= N || road.End < 0 || road.End >= N)
            {
                throw new ArgumentOutOfRangeException(nameof(road), $"Invalid road from city {road.Start + 1} to city {road.End + 1}. City indices must be between 1 and {N}.");
            }

            if (road.Start == road.End)
            {
                throw new ArgumentException("A road cannot connect a city to itself.", nameof(road));
            }
            
            dist[road.Start, road.End] = 0;  // Direct route
            dist[road.End, road.Start] = Math.Min(dist[road.End, road.Start], 1);  // Reverse route
        }
    }

    // Runs the Floyd-Warshall algorithm to calculate shortest paths
    public static void RunFloydWarshall(int N, int[,] dist)
    {
        if (dist.GetLength(0) != N || dist.GetLength(1) != N)
        {
            throw new ArgumentException("Matrix dimensions do not match the number of cities N.");
        }
        
        for (int k = 0; k < N; k++)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);
                }
            }
        }
    }

    // Finds the maximum value of K where the plan is weakly K-connected
    private static int FindMaxK(int N, int[,] dist)
    {
        int K = 0;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (i != j)
                {
                    K = Math.Max(K, dist[i, j]);
                }
            }
        }

        return K;
    }
}