using App;
using Xunit;
using Xunit.Abstractions;

namespace Tests;

public class MoneyChangeCalculatorTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public MoneyChangeCalculatorTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void CalculateChange_ValidSums_ReturnsCorrectResults()
    {
        // Arrange
        int[] coins = { 1, 3, 4 };
        int[] sums = { 6, 7, 8 };
        int[] expectedResults = { 1, 1, 1 };  // All sums can be made

        // Act
        var result = MoneyChangeCalculator.CalculateChange(coins, sums);

        // Assert
        Assert.Equal(expectedResults, result);
        _testOutputHelper.WriteLine($"Test: {nameof(CalculateChange_ValidSums_ReturnsCorrectResults)} | Inputs: coins=[{string.Join(", ", coins)}], sums=[{string.Join(", ", sums)}] | Result: [{string.Join(", ", result)}] | Status: Passed");
    }

    [Fact]
    public void CalculateChange_SomeSumsImpossible_ReturnsCorrectResults()
    {
        // Arrange
        int[] coins = { 2, 5 };
        int[] sums = { 3, 4, 10 };
        int[] expectedResults = { 0, 1, 1 };  // 3 cannot be formed, 4 and 10 can

        // Act
        var result = MoneyChangeCalculator.CalculateChange(coins, sums);

        // Assert
        Assert.Equal(expectedResults, result);
        _testOutputHelper.WriteLine($"Test: {nameof(CalculateChange_SomeSumsImpossible_ReturnsCorrectResults)} | Inputs: coins=[{string.Join(", ", coins)}], sums=[{string.Join(", ", sums)}] | Result: [{string.Join(", ", result)}] | Status: Passed");
    }

    [Fact]
    public void CalculateChange_MaxSumTooSmall_ThrowsArgumentException()
    {
        // Arrange
        int[] coins = { 2, 5 };
        int maxSum = -1;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => MoneyChangeCalculator.PrepareDpTable(coins, maxSum));
        _testOutputHelper.WriteLine($"Test: {nameof(CalculateChange_MaxSumTooSmall_ThrowsArgumentException)} | Inputs: coins=[{string.Join(", ", coins)}], maxSum={maxSum} | Exception: {exception.Message} | Status: Passed");
    }

    [Fact]
    public void CalculateChange_ZeroCoins_ReturnsCorrectResults()
    {
        // Arrange
        int[] coins = { };
        int[] sums = { 0 };
        int[] expectedResults = { 1 };  // Only sum 0 is possible without any coins

        // Act
        var result = MoneyChangeCalculator.CalculateChange(coins, sums);

        // Assert
        Assert.Equal(expectedResults, result);
        _testOutputHelper.WriteLine($"Test: {nameof(CalculateChange_ZeroCoins_ReturnsCorrectResults)} | Inputs: coins=[], sums=[{string.Join(", ", sums)}] | Result: [{string.Join(", ", result)}] | Status: Passed");
    }

    [Fact]
    public void FindMaxSum_ReturnsMaxValueFromSums()
    {
        // Arrange
        int[] sums = { 5, 10, 15, 20 };
        int expectedMax = 20;

        // Act
        int result = MoneyChangeCalculator.FindMaxSum(sums);

        // Assert
        Assert.Equal(expectedMax, result);
        _testOutputHelper.WriteLine($"Test: {nameof(FindMaxSum_ReturnsMaxValueFromSums)} | Inputs: sums=[{string.Join(", ", sums)}] | Result: {result} | Status: Passed");
    }

    [Fact]
    public void PrepareDpTable_CorrectlyPreparesTable()
    {
        // Arrange
        int[] coins = { 1, 3, 4 };
        int maxSum = 6;
        bool[] expectedDp = { true, true, true, true, true, true, true };

        // Act
        var result = MoneyChangeCalculator.PrepareDpTable(coins, maxSum);

        // Assert
        Assert.Equal(expectedDp, result);
        _testOutputHelper.WriteLine($"Test: {nameof(PrepareDpTable_CorrectlyPreparesTable)} | Inputs: coins=[{string.Join(", ", coins)}], maxSum={maxSum} | Result: [{string.Join(", ", result)}] | Status: Passed");
    }
}
