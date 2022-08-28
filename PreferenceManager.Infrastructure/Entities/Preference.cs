using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PreferenceManager.Domain.Preference;

namespace PreferenceManager.Infrastructure.Entities;

public class Preference
{
    public Preference(ICollection<PersonPreference> personPreferences, ICollection<SolutionPreference> solutionPreferences)
    {
        PersonPreferences = new HashSet<PersonPreference>();
        SolutionPreferences = new HashSet<SolutionPreference>();
    }

    public Preference(int id, string name, string description, bool universal, bool encrypted, PreferenceType type)
    {
        Id = id;
        Name = name;
        Description = description;
        Universal = universal;
        Encrypted = encrypted;
        Type = type;
    }

    public Preference(string name, string description, bool universal, bool encrypted, PreferenceType type, 
        ICollection<SolutionPreference> solutionPreferences)
    {
        Name = name;
        Description = description;
        Universal = universal;
        Encrypted = encrypted;
        Type = type;
        SolutionPreferences = solutionPreferences;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; }
    public bool Universal { get; set; }
    public bool Encrypted { get; set; }
    public PreferenceType Type { get; set; }
    public virtual ICollection<PersonPreference> PersonPreferences { get; set; }
    public virtual ICollection<SolutionPreference> SolutionPreferences { get; set; }
}