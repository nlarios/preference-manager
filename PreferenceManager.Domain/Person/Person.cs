using Aggregator;

namespace PreferenceManager.Domain.Person;

public class Person : AggregateRoot
{
    public long Id { get; set; }
    
    public long ExternalAuthId { get; set; }
    
    public PersonType Type { get; set; }
}