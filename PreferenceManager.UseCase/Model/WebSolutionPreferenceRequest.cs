using System.Text.Json.Serialization;
using PreferenceManager.Domain.Preference;

namespace PreferenceManager.UseCase.Model;

public class WebSolutionPreferenceRequest
{
    public string Name { get; }
    public string Description { get; }
    public bool Encrypted { get; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PreferenceType Type { get; }

    public List<int> SolutionIds { get; }

    public WebSolutionPreferenceRequest(string name, string description, bool encrypted, PreferenceType type,
        List<int> solutionIds)
    {
        Name = name;
        Description = description;
        Encrypted = encrypted;
        Type = type;
        SolutionIds = solutionIds;
    }
}