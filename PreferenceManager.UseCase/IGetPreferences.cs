using PreferenceManager.Domain.Preference;

namespace PreferenceManager.UseCase;

public interface IGetPreferences
{
    public IReadOnlyCollection<Preference?> GetUniversalPreferences();
}