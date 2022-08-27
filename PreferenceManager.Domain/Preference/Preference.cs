using Aggregator;

namespace PreferenceManager.Domain.Preference;

public class Preference : AggregateRoot
{
    public long Id { get; }
    
    public string Description { get; }

    public bool IsUniversal { get; }

    public PreferenceType Type { get; }
}