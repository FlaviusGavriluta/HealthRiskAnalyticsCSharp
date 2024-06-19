using CodeCool.HealthRiskAnalytics.Model;

namespace CodeCool.HealthRiskAnalytics.Service;

public class AnalyticsService
{
    private const double OverweightBmiLimit = 25.0;
    private const int OverweightYearsLimit = 3;

    public int CalculateAge(Person person)
    {
        return 0;
    }

    public double[] CalculateBmiSeries(Person person)
    {
        return Array.Empty<double>();
    }

    private static double CalculateBmi(double height, int weight)
    {
        return 0;
    }

    public WeightCondition DetermineWeightCondition(Person person)
    {
        return WeightCondition.Healthy;
    }

    public double CalculateOrr(Person[] persons)
    {
        return 0;
    }
}
