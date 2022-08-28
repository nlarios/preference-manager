using PreferenceManager.Domain.Person;

namespace PreferenceManager.Infrastructure.Entities;

public class Person
{
    public Person()
    {
        PersonPreferences = new HashSet<PersonPreference>();
    }

    public long Id { get; set; }
    public string ExternalAuthId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public PersonType Type { get; set; } = PersonType.CONSUMER;

    public virtual ICollection<PersonPreference> PersonPreferences { get; set; }
}