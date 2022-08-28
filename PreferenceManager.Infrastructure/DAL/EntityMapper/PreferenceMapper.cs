using PreferenceManager.Domain.Preference;
using PreferenceManager.Domain.Solution;

namespace PreferenceManager.Infrastructure.DAL.EntityMapper;

public static class PreferenceMapper
{
    public static Preference MapFromDbEntity(Entities.Preference? preference)
    {
        return new Preference(preference.Id, preference.Name, preference.Description, preference.Universal,
            preference.Encrypted, preference.Type);
    }

    public static Entities.Preference MapFromDomain(Preference preference)
    {
        return new Entities.Preference(preference.Id, preference.Name, preference.Description, preference.Universal,
            preference.Encrypted, preference.Type);
    }
    
    public static Entities.Preference MapFromDomain(Preference preference, List<Solution> solutions)
    {
        var solutionPreference = solutions.Select(solution =>
                new Entities.SolutionPreference(solution.Id, preference.Id))
            .ToList();
        return new Entities.Preference(preference.Name, preference.Description, preference.Universal,
            preference.Encrypted, preference.Type, solutionPreference);
    }
}