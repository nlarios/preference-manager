using PreferenceManager.Domain.Solution;

namespace PreferenceManager.Infrastructure.DAL;

public interface ISolutionRepository
{
    List<Solution> GetSolutions();

    List<Solution> GetSolutionsByIds(List<int> ids);
}