using PreferenceManager.Infrastructure.Entities;

namespace PreferenceManager.Infrastructure.DAL;

public interface ISolutionPreferenceRepository
{
    IEnumerable<SolutionPreference> GetSolutionPreference();

    Task Save();
}