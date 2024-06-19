using CodeCool.HealthRiskAnalytics.Model;
using CodeCool.HealthRiskAnalytics.Service;

namespace CodeCool.HealthRiskAnalytics;

public static class Program
{
    public static void Main(string[] args)
    {
        PersonProvider personProvider = new PersonProvider(20);
        Person[] persons = personProvider.Persons;
    }
}
