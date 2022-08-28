using System.Text.Json.Serialization;
using PreferenceManager.Domain.Preference;

namespace PreferenceManager.Model;

public class WebPreferenceResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Universal { get; set; }
    public bool Encrypted { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PreferenceType Type { get; set; }

    public WebPreferenceResponse(int id, string name, string description, bool universal, bool encrypted, PreferenceType type)
    {
        Id = id;
        Name = name;
        Description = description;
        Universal = universal;
        Encrypted = encrypted;
        Type = type;
    }
}