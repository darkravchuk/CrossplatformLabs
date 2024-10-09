namespace App;

public static class MoneyChangeCalculator
{
    public static int[] CalculateChange(int[] coins, int[] sums)
    {
        int maxSum = FindMaxSum(sums);
        var dp = PrepareDpTable(coins, maxSum);
    
        return GetResultForSums(sums, dp);
    }

    public static int FindMaxSum(int[] sums)
    {
        int maxSum = sums[0]; 
    
        for (int i = 1; i < sums.Length; i++)
        {
            if (sums[i] > maxSum)
            {
                maxSum = sums[i]; 
            }
        }

        return maxSum; 
    }

    public static bool[] PrepareDpTable(int[] coins, int maxSum)
    {
        if (maxSum < 0)
            throw new ArgumentException();
        
        var dp = new bool[maxSum + 1];
        dp[0] = true;

        foreach (var coin in coins)
        {
            for (int i = coin; i <= maxSum; i++)
            {
                if (dp[i - coin])
                {
                    dp[i] = true;
                }
            }
        }

        return dp;
    }

    private static int[] GetResultForSums(int[] sums, bool[] dp)
    {
        var result = new int[sums.Length];
        for (int i = 0; i < sums.Length; i++)
        {
            result[i] = dp[sums[i]] ? 1 : 0;
        }
        
        return result;
    }
}