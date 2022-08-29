using PreferenceManager.Infrastructure.Entities;

namespace PreferenceManager.UseCase;

public interface IGetPersonPreferences
{
    List<PersonPreference> GetPersonPreferencesForExternalId(string externalAuthId);
    
}