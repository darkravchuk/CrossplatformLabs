using App;
using Xunit.Abstractions;

namespace Tests
{
    public class WeaklyConnectedSolverTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public WeaklyConnectedSolverTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Solve_ValidInputWithNoViolations_ReturnsZero()
        {
            // Arrange
            int N = 4;
            var roads = new (int Start, int End)[]
            {
                (1 - 1, 3 - 1), // Convert to zero-based index
                (2 - 1, 4 - 1),
                (4 - 1, 1 - 1),
                (3 - 1, 2 - 1)
            };

            // Act
            int result = WeaklyConnectedSolver.Solve(N, roads);

            // Assert
            Assert.Equal(0, result);
            _testOutputHelper.WriteLine($"Test: {nameof(Solve_ValidInputWithNoViolations_ReturnsZero)} | Cities: {N} | Roads: {string.Join(", ", roads)} | Result: {result} | Status: Passed");
        }

        [Fact]
        public void Solve_InvalidCityIndex_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int N = 3;
            var roads = new (int Start, int End)[]
            {
                (0, 3),  // Invalid city index
                (1, 2)
            };

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => WeaklyConnectedSolver.Solve(N, roads));
            _testOutputHelper.WriteLine($"Test: {nameof(Solve_InvalidCityIndex_ThrowsArgumentOutOfRangeException)} | Cities: {N} | Roads: {string.Join(", ", roads)} | Exception: {exception.Message} | Status: Passed");
        }

        [Fact]
        public void Solve_RoadConnectingSameCity_ThrowsArgumentException()
        {
            // Arrange
            int N = 3;
            var roads = new (int Start, int End)[]
            {
                (0, 0),  // Road connecting the same city
                (1, 2)
            };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => WeaklyConnectedSolver.Solve(N, roads));
            _testOutputHelper.WriteLine($"Test: {nameof(Solve_RoadConnectingSameCity_ThrowsArgumentException)} | Cities: {N} | Roads: {string.Join(", ", roads)} | Exception: {exception.Message} | Status: Passed");
        }

        [Fact]
        public void InitializeDistanceMatrix_InvalidN_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int invalidN = -1;

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => WeaklyConnectedSolver.InitializeDistanceMatrix(invalidN));
            _testOutputHelper.WriteLine($"Test: {nameof(InitializeDistanceMatrix_InvalidN_ThrowsArgumentOutOfRangeException)} | Invalid Cities: {invalidN} | Exception: {exception.Message} | Status: Passed");
        }

        [Fact]
        public void RunFloydWarshall_InvalidMatrixSize_ThrowsArgumentException()
        {
            // Arrange
            int N = 3;
            int[,] invalidDist = new int[2, 2];  // Invalid matrix size

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => WeaklyConnectedSolver.RunFloydWarshall(N, invalidDist));
            _testOutputHelper.WriteLine($"Test: {nameof(RunFloydWarshall_InvalidMatrixSize_ThrowsArgumentException)} | Cities: {N} | Invalid Matrix Size: {invalidDist.GetLength(0)}x{invalidDist.GetLength(1)} | Exception: {exception.Message} | Status: Passed");
        }

        [Fact]
        public void AddRoadsToGraph_InvalidRoadIndex_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int N = 3;
            var roads = new (int Start, int End)[]
            {
                (0, 3),  // Invalid road index
                (1, 2)
            };
            int[,] dist = WeaklyConnectedSolver.InitializeDistanceMatrix(N);

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => WeaklyConnectedSolver.AddRoadsToGraph(N, dist, roads));
            _testOutputHelper.WriteLine($"Test: {nameof(AddRoadsToGraph_InvalidRoadIndex_ThrowsArgumentOutOfRangeException)} | Cities: {N} | Roads: {string.Join(", ", roads)} | Exception: {exception.Message} | Status: Passed");
        }

        [Fact]
        public void AddRoadsToGraph_RoadConnectingSameCity_ThrowsArgumentException()
        {
            // Arrange
            int N = 3;
            var roads = new (int Start, int End)[]
            {
                (0, 0),  // Road connecting the same city
                (1, 2)
            };
            int[,] dist = WeaklyConnectedSolver.InitializeDistanceMatrix(N);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => WeaklyConnectedSolver.AddRoadsToGraph(N, dist, roads));
            _testOutputHelper.WriteLine($"Test: {nameof(AddRoadsToGraph_RoadConnectingSameCity_ThrowsArgumentException)} | Cities: {N} | Roads: {string.Join(", ", roads)} | Exception: {exception.Message} | Status: Passed");
        }
    }
}
