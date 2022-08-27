using Microsoft.AspNetCore.SignalR;
using PreferenceManager.Domain.Preference;

namespace PreferenceManager.Domain.Person;

public class UserPreference
{
     public Person Person;
     public Preference.Preference Preference { get; }
     public string Content;
     public string? EncryptedKey;
}