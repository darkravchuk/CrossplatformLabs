using System.Numerics;

namespace ClassLibraryLabs.Lab1;

public static class MoneyDistributor
{
    private const int BillDenomination = 5;
    private const int MaxMoneyAmount = 500;
    private const int MinMoneyAmount = 0;
    private const int MaxParticipants = 100;
    private const int MinParticipants = 0;

    public static BigInteger CountWays(int moneyAmount, int kids)
    {
        if (moneyAmount < MinMoneyAmount || moneyAmount > MaxMoneyAmount)
            throw new ArgumentException($"The money amount must be between {MinMoneyAmount} and {MaxMoneyAmount}.");
        if (kids < MinParticipants || kids > MaxParticipants)
            throw new ArgumentException($"The number of participants must be between {MinParticipants} and {MaxParticipants}.");
        
        int banknotes = CountBanknotes(moneyAmount);
        int participants = kids + 1;

        return CombinationCalculator.Comb(banknotes + participants - 1, participants - 1);
    }

    private static int CountBanknotes(int moneyAmount)
    {
        if (moneyAmount % BillDenomination != 0)
            throw new ArgumentException($"The money amount must be divisible by {BillDenomination}.", nameof(moneyAmount));

        return moneyAmount / BillDenomination;
    }
}
