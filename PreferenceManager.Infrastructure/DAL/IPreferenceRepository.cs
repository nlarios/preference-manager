using PreferenceManager.Domain.Preference;
using PreferenceManager.Domain.Solution;

namespace PreferenceManager.Infrastructure.DAL;

public interface IPreferenceRepository
{
    IEnumerable<Preference?> GetPreferences();
    IEnumerable<Preference?> GetUniversalPreferences();
    Preference? GetPreferenceById(int preferenceId);
    Task<Preference> InsertSolutionPreference(Preference preference, List<Solution> solutions);
    Task<Preference> InsertPreference(Preference preference);
    void DeletePreference(int preferenceId);
    void UpdatePreference(Preference preference);
    Task Save();
}