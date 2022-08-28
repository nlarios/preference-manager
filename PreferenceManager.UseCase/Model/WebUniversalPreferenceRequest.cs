using System.Text.Json.Serialization;
using PreferenceManager.Domain.Preference;

namespace PreferenceManager.UseCase.Model;

public class WebUniversalPreferenceRequest
{
    public string Name { get; }
    public string Description { get; }
    public bool Encrypted { get; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PreferenceType Type { get; }

    public WebUniversalPreferenceRequest(string name, string description, bool encrypted, PreferenceType type)
    {
        Name = name;
        Description = description;
        Encrypted = encrypted;
        Type = type;
    }
}