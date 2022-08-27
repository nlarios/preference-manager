namespace PreferenceManager.Domain.Solution;

public class Solution
{
    public long Id { get; }
    
    public string Name { get; set; }
    
    private string Host { get; }
    
    private List<Preference.Preference> Preferences { get; }
}