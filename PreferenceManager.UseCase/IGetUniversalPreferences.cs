using PreferenceManager.Domain.Preference;

namespace PreferenceManager.UseCase;

public interface IGetUniversalPreferences
{
    public ICollection<Preference> GetPreferences();
}