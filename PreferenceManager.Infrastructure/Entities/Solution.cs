namespace PreferenceManager.Infrastructure.Entities;

public class Solution
{
    public Solution()
    {
        SolutionPreferences = new HashSet<SolutionPreference>();
    }

    public Solution(int id, string name, string host)
    {
        Id = id;
        Name = name;
        Host = host;
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Host { get; set; } = null!;

    public virtual ICollection<SolutionPreference> SolutionPreferences { get; set; }
}