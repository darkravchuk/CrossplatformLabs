using App;
using Xunit.Abstractions;

namespace Tests;

public class CombinationCalculatorTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public CombinationCalculatorTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 6)]
    public void Factorial_ReturnsExpectedResult(int n, int expected)
    {
        // Act
        var result = CombinationCalculator.Factorial(n);
        
        // Assert
        Assert.Equal(expected, result);
        _testOutputHelper.WriteLine($"Test: {nameof(Factorial_ReturnsExpectedResult)} | Input: {n} | Expected: {expected} | Actual: {result} | Status: Passed");
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-10)]
    public void Factorial_ThrowsExceptionWhenProvidedNIsInvalid(int n)
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => CombinationCalculator.Factorial(n));
        
        _testOutputHelper.WriteLine($"Test: {nameof(Factorial_ThrowsExceptionWhenProvidedNIsInvalid)} | Input: {n} | Exception: {exception.Message} | Status: Passed");
    }

    [Theory]
    [InlineData(8, 3, 56)]
    [InlineData(12, 3, 220)]
    [InlineData(7, 2, 21)]
    [InlineData(5, 1, 5)]
    public void Comb_ReturnsExpectedResult(int n, int k, long expected)
    {
        // Act
        var result = CombinationCalculator.Comb(n, k);
        
        // Assert
        Assert.Equal(expected, result);
        _testOutputHelper.WriteLine($"Test: {nameof(Comb_ReturnsExpectedResult)} | Inputs: n={n}, k={k} | Expected: {expected} | Actual: {result} | Status: Passed");
    }

    [Theory]
    [InlineData(1, 8)]
    [InlineData(3, 12)]
    [InlineData(7, -1)]
    [InlineData(-1, 1)]
    public void Comb_ThrowsArgumentExceptionWhenParametersAreInvalid(int n, int k)
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => CombinationCalculator.Comb(n, k));
        
        _testOutputHelper.WriteLine($"Test: {nameof(Comb_ThrowsArgumentExceptionWhenParametersAreInvalid)} | Inputs: n={n}, k={k} | Exception: {exception.Message} | Status: Passed");
    }
}
