using CodeCool.HealthRiskAnalytics.Model;

namespace CodeCool.HealthRiskAnalytics.Service;

public class PersonProvider
{
    private static readonly Random Random = new();

    public Person[] Persons { get; }

    public PersonProvider(int count)
    {
        Persons = GenerateRandomPersons(count);
    }

    private static Person[] GenerateRandomPersons(int count)
    {
        int id = 0;
        Person[] persons = new Person[count];

        for (int i = 0; i < count; i++)
        {
            persons[i] = new Person(id++, GetRandomBirthDate(), GetRandomGender(), GetRandomHeight(),
                GetRandomWeights());
        }

        return persons;
    }

    private static string GetRandomBirthDate()
    {
        int year = Random.Next(1950, 2000);
        int month = Random.Next(1, 12);
        int day = Random.Next(1, 25);

        return day + "/" + month + "/" + year;
    }

    private static double GetRandomHeight()
    {
        return Utilities.GetRandomDoubleWithinRange(Random, 1.5, 1.95);
    }

    private static int[] GetRandomWeights()
    {
        int rangeStart = Random.Next(40, 110);
        int[] weights = new int[5];

        for (int i = 0; i < 5; i++)
        {
            weights[i] = Random.Next(rangeStart, rangeStart + 10);
        }

        return weights;
    }

    private static Gender GetRandomGender()
    {
        double chance = Utilities.GetRandomDoubleWithinRange(Random, 0, 1);
        if (chance > 0.5)
        {
            return Gender.Male;
        }
        return Gender.Female;
    }
}
