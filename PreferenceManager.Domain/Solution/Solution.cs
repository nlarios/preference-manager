using Aggregator;

namespace PreferenceManager.Domain.Solution;

public class Solution : AggregateRoot
{
    public int Id { get; }
    
    public string Name { get; set; }
    
    private string Host { get; }
    
    private List<Preference.Preference> Preferences { get; }

    public Solution(int id, string name, string host, List<Preference.Preference> preferences)
    {
        Id = id;
        Name = name;
        Host = host;
        Preferences = preferences;
    }
}