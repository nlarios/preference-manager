using Aggregator;
using PreferenceManager.Domain.Person;

namespace PreferenceManager.Domain.Preference;

public class Preference : AggregateRoot
{
    public int Id { get; }

    public string Name { get; }

    public string Description { get; }

    public bool Universal { get; }

    public bool Encrypted { get; }

    public PreferenceType Type { get; }

    private List<Solution.Solution> Solutions { get; }

    
    public Preference(int id, string name, string description, bool universal, bool encrypted, PreferenceType type)
    {
        Id = id;
        Name = name;
        Description = description;
        Universal = universal;
        Encrypted = encrypted;
        Type = type;
    }

    private Preference(string name, string description, bool universal, bool encrypted, PreferenceType type)
    {
        Name = name;
        Description = description;
        Universal = universal;
        Encrypted = encrypted;
        Type = type;
    }

    // SolutionPreference Constructors
    private Preference(string name, string description, bool universal, bool encrypted, PreferenceType type,
        List<Solution.Solution> solutions)
    {
        Name = name;
        Description = description;
        Universal = universal;
        Encrypted = encrypted;
        Type = type;
        Solutions = solutions;
    }
    
    public Preference(int id, string name, string description, bool universal, bool encrypted, PreferenceType type,
        List<Solution.Solution> solutions)
    {
        Id = id;
        Name = name;
        Description = description;
        Universal = universal;
        Encrypted = encrypted;
        Type = type;
        Solutions = solutions;
    }

    public static Preference CreateUniversalPreference(string name, string description, bool encrypted,
        PreferenceType preferenceType, PersonType personType)
    {
        if (personType == PersonType.ADMIN)
        {
            return new Preference(name, description, true, encrypted, preferenceType);
        }
        else
        {
            throw new ArgumentException("Wrong user type trying to create a universal preference");
        }
    }

    public static Preference CreateSolutionPreference(string name, string description, bool encrypted,
        PreferenceType preferenceType, List<Solution.Solution> solutions, PersonType personType)
    {
        if (personType == PersonType.SOLUTION_MANAGER)
        {
            return new Preference(name, description, false, encrypted, preferenceType, solutions);
        }
        else
        {
            throw new ArgumentException("Wrong user type trying to create a universal preference");
        }
    }
}