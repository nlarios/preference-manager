using PreferenceManager.Domain.Person;

namespace PreferenceManager.Infrastructure.DAL;

public class PersonRepository : IPersonRepository, IDisposable
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Person? FindByExternalAuthId(string externalAuthId)
    {
        throw new NotImplementedException();
    }
}