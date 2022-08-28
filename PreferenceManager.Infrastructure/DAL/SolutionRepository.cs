using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PreferenceManager.Domain.Solution;
using PreferenceManager.Infrastructure.Context;
using PreferenceManager.Infrastructure.DAL.EntityMapper;
using PreferenceManager.Infrastructure.Entities;
using Solution = PreferenceManager.Domain.Solution.Solution;

namespace PreferenceManager.Infrastructure.DAL;

public class SolutionRepository : ISolutionRepository, IDisposable
{
     private readonly PmDbContext context;

    private bool disposed;

    public SolutionRepository(PmDbContext context)
    {
        this.context = context;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public List<Solution> GetSolutions()
    {
        using var dbContextTransaction = context.Database.BeginTransaction();
        var solutions = context.Solutions
            .Select(SolutionMapper.MapFromDbEntity)
            .ToList();
        dbContextTransaction.Commit();
        return solutions;
    }
    
    public List<Solution> GetSolutionsByIds(List<int> ids)
    {
        using var dbContextTransaction = context.Database.BeginTransaction();
        var solutions = context.Solutions
            .Where(t => ids.Contains(t.Id)).AsEnumerable()
            .Select(SolutionMapper.MapFromDbEntity)
            .ToList();
        dbContextTransaction.Commit();
        return solutions;
    }
    
    public Solution? GetSolutionById(int id)
    {
        return SolutionMapper.MapFromDbEntity(context.Solutions.Find(id));
    }
    

    public void DeleteSolution(int SolutionId)
    {
        var Solution = context.Solutions.Find(SolutionId);
        if (Solution != null) context.Solutions.Remove(Solution);
    }
    
    public async Task Save()
    {
        await context.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
            if (disposing)
                context.Dispose();

        disposed = true;
    }
}