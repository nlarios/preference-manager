using Microsoft.EntityFrameworkCore;
using PreferenceManager.Domain.Preference;
using PreferenceManager.Infrastructure.Context;

namespace PreferenceManager.UseCase;

public class GetUniversalPreferencesUseCase : IGetUniversalPreferences
{
    private DbContext dbContext;
    public GetUniversalPreferencesUseCase(PmDbContext pmDbContext)
    {
        dbContext = pmDbContext;
    }
    public ICollection<Preference> GetPreferences()
    {
        return null;
    }
}