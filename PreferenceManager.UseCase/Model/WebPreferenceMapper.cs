using PreferenceManager.Domain.Preference;
using PreferenceManager.Model;

namespace PreferenceManager.UseCase.Model;

public class WebPreferenceMapper
{
    public static WebPreferenceResponse MapPreferenceResponse(Preference? preference)
    {
        return new WebPreferenceResponse(preference.Id, preference.Name, preference.Description,
            preference.Universal, preference.Encrypted, preference.Type);
    }
}