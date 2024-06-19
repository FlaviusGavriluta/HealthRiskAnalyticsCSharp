using CodeCool.HealthRiskAnalytics.Model;
using CodeCool.HealthRiskAnalytics.Service;

namespace CodeCool.HealthRiskAnalyticsTest;

public class AnalyticsServiceTest
{
    private static readonly int CurrentMonth = DateTime.Now.Month;
    private static readonly int CurrentYear = DateTime.Now.Year;

    private readonly AnalyticsService _analyticsService = new();

    [Test]
    public void CalculateAgeWhenCurrentTimeIsAfterBirthday()
    {
        int birthYear = 1992;
        int expected = CurrentYear - birthYear;
        String birthDate = "21/" + (CurrentMonth - 1) + "/" + birthYear;

        int age = _analyticsService.CalculateAge(APerson(birthDate));

        Assert.That(expected, Is.EqualTo(age));
    }

    [Test]
    public void CalculateAgeWhenCurrentTimeIsBeforeBirthday()
    {
        int birthYear = 1992;
        int expected = CurrentYear - birthYear - 1;
        String birthDate = "21/" + (CurrentMonth + 1) + "/" + birthYear;

        int age = _analyticsService.CalculateAge(APerson(birthDate));

        Assert.That(expected, Is.EqualTo(age));
    }

    [Test]
    public void CalculateBmiSeriesReturnsArrayWithCorrectSize()
    {
        Person person = HealthyPerson();

        double[] bmiSeries = _analyticsService.CalculateBmiSeries(person);

        Assert.That(bmiSeries.Length, Is.EqualTo(person.Weights.Length));
    }

    [Test]
    public void CalculateBmiSeriesReturnsCorrectValues()
    {
        int[] weights = { 60, 61, 63, 65, 61 };
        Person person = APerson(weights);

        double[] expectedBmiSeries = weights
            .Select(w => (w / Math.Pow(person.Height, 2)))
            .ToArray();

        double[] bmiSeries = _analyticsService.CalculateBmiSeries(person);

        Assert.That(expectedBmiSeries, Is.EqualTo(bmiSeries));
    }

    [Test]
    public void DetermineWeightConditionReturnsOverWeight()
    {
        Person overWeightPerson = OverweightPerson();

        WeightCondition weightCondition = _analyticsService.DetermineWeightCondition(overWeightPerson);

        Assert.That(weightCondition, Is.EqualTo(WeightCondition.Overweight));
    }

    [Test]
    public void DetermineWeightConditionReturnsHealthy()
    {
        Person healthyPerson = HealthyPerson();

        WeightCondition weightCondition = _analyticsService.DetermineWeightCondition(healthyPerson);

        Assert.That(weightCondition, Is.EqualTo(WeightCondition.Healthy));
    }

    [Test]
    public void DetermineWeightConditionReturnsUnknown()
    {
        Person person = APerson(new[] { 60 });

        WeightCondition weightCondition = _analyticsService.DetermineWeightCondition(person);

        Assert.That(weightCondition, Is.EqualTo(WeightCondition.Unknown));
    }

    [Test]
    public void CalculateOrrReturnsCorrectValue()
    {
        Person[] persons = {
            OverweightPerson(),
            HealthyPerson(),
            OverweightPerson(),
            HealthyPerson()
        };

        double orr = _analyticsService.CalculateOrr(persons);

        Assert.That(orr, Is.EqualTo(0.5));
    }

    private Person OverweightPerson()
    {
        return OverweightPerson(Gender.Male);
    }

    private Person OverweightPerson(Gender gender)
    {
        return new Person(1, "21/7/1992", gender, 1.7, new[] { 100, 103, 110, 109, 108 });
    }

    private Person HealthyPerson()
    {
        return HealthyPerson(Gender.Male);
    }

    private Person HealthyPerson(Gender gender)
    {
        return new Person(1, "21/7/1992", gender, 1.7, new[] { 60, 61, 63, 65, 61 });
    }

    private Person APerson(String birthDate)
    {
        return new Person(1, birthDate, Gender.Male, 1.7, new[] { 60, 61, 63, 65, 61 });
    }

    private Person APerson(int[] weights)
    {
        return new Person(1, "21/7/1992", Gender.Male, 1.7, weights);
    }
}
