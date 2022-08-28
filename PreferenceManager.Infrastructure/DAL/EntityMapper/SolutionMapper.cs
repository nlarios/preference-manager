using PreferenceManager.Infrastructure.Entities;
using Preference = PreferenceManager.Domain.Preference.Preference;
using Solution = PreferenceManager.Domain.Solution.Solution;

namespace PreferenceManager.Infrastructure.DAL.EntityMapper;

public static class SolutionMapper
{
    public static Solution MapFromDbEntity(Entities.Solution solutionEntity)
    {
        var preferences = solutionEntity.SolutionPreferences.Select(
                preference => PreferenceMapper.MapFromDbEntity(preference.Preference))
            .ToList();
        
        return new Solution(solutionEntity.Id, solutionEntity.Name, solutionEntity.Host,
            preferences);
    }
}