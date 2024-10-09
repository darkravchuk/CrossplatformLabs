using App;
using Xunit.Abstractions;

namespace Tests;

public class MoneyDistributorTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public MoneyDistributorTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Theory]
    [InlineData(15, 2, 10)]
    [InlineData(150, 2, 496)]
    public void CountWays_ReturnsExpectedResult(int money, int kids, long expectedWays)
    {
        // Act
        var actualWays = MoneyDistributor.CountWays(money, kids);
        
        // Assert
        Assert.Equal(expectedWays, actualWays);

        _testOutputHelper.WriteLine($"Test: {nameof(CountWays_ReturnsExpectedResult)} | Money: {money}, Kids: {kids} | Expected Ways: {expectedWays} | Actual Ways: {actualWays} | Status: Passed");
    }
    
    [Theory]
    [InlineData(510, 2)]
    [InlineData(-15, 2)]
    public void CountWays_ThrowsArgumentExceptionWhenMoneyNotInRange(int money, int kids)
    {
        // Act
        Action act = () => MoneyDistributor.CountWays(money, kids);

        // Assert
        var exception = Assert.Throws<ArgumentException>(act);
        
        _testOutputHelper.WriteLine($"Test: {nameof(CountWays_ThrowsArgumentExceptionWhenMoneyNotInRange)} | Money: {money}, Kids: {kids} | Exception: {exception.Message} | Status: Passed");
    }
    
    [Theory]
    [InlineData(50, 200)]
    [InlineData(200, -2)]
    public void CountWays_ThrowsArgumentExceptionWhenKidsNotInRange(int money, int kids)
    {
        // Act
        Action act = () => MoneyDistributor.CountWays(money, kids);
        
        // Assert
        var exception = Assert.Throws<ArgumentException>(act);
        
        _testOutputHelper.WriteLine($"Test: {nameof(CountWays_ThrowsArgumentExceptionWhenKidsNotInRange)} | Money: {money}, Kids: {kids} | Exception: {exception.Message} | Status: Passed");
    }
}
