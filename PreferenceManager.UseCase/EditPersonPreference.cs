using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using PreferenceManager.Domain.Person;
using PreferenceManager.Infrastructure.Cache;
using PreferenceManager.Infrastructure.Context;
using PreferenceManager.Infrastructure.DAL;
using PreferenceManager.UseCase.Model;
using Preference = PreferenceManager.Domain.Preference.Preference;

namespace PreferenceManager.UseCase;

public class EditPersonPreference : IEditPersonPreference
{

    private PmDbContext _pmDbContext;
    private IPreferenceRepository _preferenceRepository;
    private IPersonRepository _personRepository;
    private IPersonPreferenceRepository _personPreferenceRepository;
    private readonly IDistributedCache _cache;

    public EditPersonPreference(PmDbContext pmDbContext, IPreferenceRepository preferenceRepository,
        IPersonPreferenceRepository personPreferenceRepository, IPersonRepository personRepository, IDistributedCache cache)
    {
        _pmDbContext = pmDbContext;
        _preferenceRepository = preferenceRepository;
        _personRepository = personRepository;
        _cache = cache;
    }

    public async Task<PersonPreference> AddPersonPreference(WebPersonPreferenceRequest request)
    {

        await using (_pmDbContext.Database.BeginTransaction())
        {
            var externalAuthId = request.ExternalAuthId;
            var preference = _preferenceRepository.GetPreferenceById(request.PreferenceId);
            var person = _personRepository.FindByExternalAuthId(externalAuthId);
            var newPersonPreference = PersonPreference.CreatePersonPreference(person, request.Content,
                preference);
            
            AddPreferenceToCache(externalAuthId, preference, newPersonPreference);
            return _personPreferenceRepository.Save(newPersonPreference);
        }
    }

    public PersonPreference UpdatePersonPreference(WebPersonPreferenceRequest webPersonPreferenceRequest)
    {
        throw new NotImplementedException();
    }

    private async void AddPreferenceToCache(string externalAuthId, Preference preference, PersonPreference personPreference )
    {
        // TODO implement Add to cache logic
        // cacheKe: externalAuthId, value: PersonPreferenceCacheDoc
    }
}