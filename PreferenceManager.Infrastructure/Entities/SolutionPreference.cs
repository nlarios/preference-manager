namespace PreferenceManager.Infrastructure.Entities;

public class SolutionPreference
{
    public int Id { get; set; }
    public int SolutionId { get; set; }
    public int PreferenceId { get; set; }

    public SolutionPreference(int solutionId, int preferenceId)
    {
        SolutionId = solutionId;
        PreferenceId = preferenceId;
    }

    public virtual Preference Preference { get; set; } = null!;
    public virtual Solution Solution { get; set; } = null!;
}