using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PreferenceManager.Domain.Person;
using PreferenceManager.Domain.Preference;
using PreferenceManager.Domain.Solution;
using PreferenceManager.Infrastructure.Context;
using PreferenceManager.Infrastructure.DAL;
using PreferenceManager.Model;
using PreferenceManager.UseCase.Model;

namespace PreferenceManager.UseCase;

public class AddPreference : IAddPreference
{
    private IPreferenceRepository preferenceRepository;
    private ISolutionRepository solutionRepository;
    private PmDbContext context;

    public AddPreference(IPreferenceRepository preferenceRepository, ISolutionRepository solutionRepository, PmDbContext context)
    {
        this.preferenceRepository = preferenceRepository;
        this.solutionRepository = solutionRepository;
        this.context = context;
    }

    public async Task<Preference> AddUniversalPreference(WebUniversalPreferenceRequest request, PersonType personType)
    {
        var preference = Preference.CreateUniversalPreference(request.Name, request.Description, request.Encrypted,
            request.Type, personType);
        return await preferenceRepository.InsertPreference(preference);
    }

    public async Task<Preference> AddSolutionPreference(WebSolutionPreferenceRequest request, PersonType personType)
    {
        IDbContextTransaction dbContextTransaction = null;
        try
        {
            dbContextTransaction = context.Database.BeginTransaction();
            var solutions = solutionRepository.GetSolutionsByIds(request.SolutionIds);
            if (solutions.Count != request.SolutionIds.Count)
            {
                throw new ArgumentException("One of the solution ids doesn't exist");
            }

            var preference = Preference.CreateSolutionPreference(request.Name, request.Description, request.Encrypted,
                request.Type, solutions, PersonType.SOLUTION_MANAGER);

            preference = await preferenceRepository.InsertPreference(preference);
            
            await dbContextTransaction.CommitAsync();
            return preference;
        }
        catch (Exception)
        {
            if (dbContextTransaction != null)
                await dbContextTransaction.RollbackAsync();

            throw;
        }
        finally
        {
            if (dbContextTransaction != null)
                await dbContextTransaction.DisposeAsync();
        }
    }
}