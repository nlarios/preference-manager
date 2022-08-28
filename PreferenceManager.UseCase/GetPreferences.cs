using PreferenceManager.Domain.Preference;
using PreferenceManager.Infrastructure.DAL;

namespace PreferenceManager.UseCase;

public class GetPreferences : IGetPreferences
{
    private IPreferenceRepository PreferenceRepository;
    
    public GetPreferences(IPreferenceRepository preferenceRepository)
    { 
        PreferenceRepository = preferenceRepository;
    }
    
    public List<Preference?> GetUniversalPreferences()
    {
        return PreferenceRepository.GetUniversalPreferences().ToList();
    }
    
    public List<Preference> GetPreferencesForSolution(int solutionId)
    {
        throw new NotImplementedException(); 
    }
}