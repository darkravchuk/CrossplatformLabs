using System.Numerics;

namespace App;

public static class CombinationCalculator
{
    public static BigInteger Factorial(int n)
    {
        if (n < 0)
            throw new ArgumentException("The factorial input must be non-negative.", nameof(n));
        
        BigInteger result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        
        return result;
    }

    public static BigInteger Comb(int n, int k)
    {
        if (n < 0 || k < 0)
            throw new ArgumentException("Both parameters must be non-negative.");
        if (k > n)
            throw new ArgumentException("The second parameter must not exceed the first one.");
        
        BigInteger numerator = Factorial(n);
        BigInteger denominator = Factorial(k) * Factorial(n - k);
        
        return numerator / denominator;
    }
}
