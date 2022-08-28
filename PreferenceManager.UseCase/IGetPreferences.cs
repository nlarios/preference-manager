using PreferenceManager.Domain.Preference;

namespace PreferenceManager.UseCase;

public interface IGetPreferences
{
    public List<Preference?> GetUniversalPreferences();
}