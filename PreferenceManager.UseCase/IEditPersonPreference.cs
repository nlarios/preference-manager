using PreferenceManager.Domain.Person;
using PreferenceManager.UseCase.Model;

namespace PreferenceManager.UseCase;

public interface IEditPersonPreference
{
    Task<PersonPreference> AddPersonPreference(WebPersonPreferenceRequest webPersonPreferenceRequest);

    PersonPreference UpdatePersonPreference(WebPersonPreferenceRequest webPersonPreferenceRequest);
    
}