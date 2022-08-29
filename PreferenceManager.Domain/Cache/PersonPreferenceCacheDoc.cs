using PreferenceManager.Domain.Preference;

namespace PreferenceManager.Infrastructure.Cache;

public class PersonPreferenceCacheDoc
{
    
    public int PreferenceId { get; }

    public string PreferenceName { get; }

    public string Description { get; }

    public bool Universal { get; }

    public bool Encrypted { get; }
    
    public PreferenceType Type { get; }
    
    public string Content;
    
    public string? EncryptedKey;
}