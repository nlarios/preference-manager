using PreferenceManager.Domain.Person;

namespace PreferenceManager.Infrastructure.DAL;

public interface IPersonPreferenceRepository
{
    PersonPreference Save(PersonPreference personPreference);
}