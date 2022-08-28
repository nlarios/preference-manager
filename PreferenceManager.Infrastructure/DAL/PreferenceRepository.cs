using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PreferenceManager.Domain.Preference;
using PreferenceManager.Domain.Solution;
using PreferenceManager.Infrastructure.Context;
using PreferenceManager.Infrastructure.DAL.EntityMapper;

namespace PreferenceManager.Infrastructure.DAL;

public class PreferenceRepository : IPreferenceRepository, IDisposable
{
    private readonly PmDbContext context;

    private bool disposed;

    public PreferenceRepository(PmDbContext context)
    {
        this.context = context;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public IEnumerable<Preference?> GetUniversalPreferences()
    {
        using var dbContextTransaction = context.Database.BeginTransaction();
        var preferences = context.Preferences
            .Where(preference => preference.Universal == true)
            .ToList()
            .Select(PreferenceMapper.MapFromDbEntity);
        dbContextTransaction.Commit();
        return preferences;
    }

    public IEnumerable<Preference?> GetPreferences()
    {
        using var dbContextTransaction = context.Database.BeginTransaction();
        var preferences = context.Preferences
            .ToList()
            .Select(PreferenceMapper.MapFromDbEntity);
        dbContextTransaction.Commit();
        return preferences;
    }

    public Preference? GetPreferenceById(int id)
    {
        return PreferenceMapper.MapFromDbEntity(context.Preferences.Find(id));
    }
    
    public async Task<Preference> InsertSolutionPreference(Preference preference, List<Solution> solutions)
    {
        var entity = context.Preferences.Add(PreferenceMapper.MapFromDomain(preference, solutions));

            await Save();
            return PreferenceMapper.MapFromDbEntity(entity.Entity);
    }
    
    public async Task<Preference> InsertPreference(Preference preference)
    {
        IDbContextTransaction dbContextTransaction = null;
        try
        {
            dbContextTransaction = context.Database.BeginTransaction();
            var entity = context.Preferences.Add(PreferenceMapper.MapFromDomain(preference));

            await Save();
            await dbContextTransaction.CommitAsync();
            return PreferenceMapper.MapFromDbEntity(entity.Entity);
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

    public void DeletePreference(int preferenceId)
    {
        var preference = context.Preferences.Find(preferenceId);
        if (preference != null) context.Preferences.Remove(preference);
    }

    public void UpdatePreference(Preference preference)
    {
        context.Entry(PreferenceMapper.MapFromDomain(preference)).State = EntityState.Modified;
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