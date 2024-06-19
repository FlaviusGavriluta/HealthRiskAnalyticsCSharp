namespace CodeCool.HealthRiskAnalytics.Service;

public static class Utilities
{
    public static double GetRandomDoubleWithinRange(Random random, double lowerBound, double upperBound)
    {
        var rDouble = random.NextDouble();
        var rRangeDouble = rDouble * (upperBound - lowerBound) + lowerBound;
        return rRangeDouble;
    }

    public static double RoundToTwoDecimals(double number) {
        return Math.Round(number,2);
    }
}
