using PreferenceManager.Domain.Person;
using PreferenceManager.Domain.Preference;
using PreferenceManager.Model;
using PreferenceManager.UseCase.Model;

namespace PreferenceManager.UseCase;

public interface IAddPreference
{
    public Task<Preference> AddUniversalPreference(WebUniversalPreferenceRequest request, PersonType personType);
    
    public Task<Preference> AddSolutionPreference(WebSolutionPreferenceRequest request, PersonType personType);
}