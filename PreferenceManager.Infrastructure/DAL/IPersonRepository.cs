using PreferenceManager.Domain.Person;

namespace PreferenceManager.Infrastructure.DAL;

public interface IPersonRepository
{
    Person? FindByExternalAuthId(string externalAuthId);
}