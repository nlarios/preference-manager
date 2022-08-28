using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PreferenceManager.Infrastructure.Context;
using PreferenceManager.Infrastructure.DAL.EntityMapper;
using PreferenceManager.Infrastructure.Entities;

namespace PreferenceManager.Infrastructure.DAL;

public class SolutionPreferenceRepository : ISolutionPreferenceRepository, IDisposable
{
    private readonly PmDbContext context;

    private bool disposed;

    public SolutionPreferenceRepository(PmDbContext context)
    {
        this.context = context;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public IEnumerable<SolutionPreference> GetSolutionPreference()
    {
        throw new NotImplementedException();
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