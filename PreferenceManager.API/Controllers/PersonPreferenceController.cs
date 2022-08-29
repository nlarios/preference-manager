using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreferenceManager.Model;
using PreferenceManager.UseCase;
using PreferenceManager.UseCase.Model;

namespace PreferenceManager.Controllers;

[Route("person-preferences")]
[Authorize]
public class PersonPreferenceController
{
    private IGetPersonPreferences _getPersonPreferences;
    private IEditPersonPreference _editPersonPreference;

    public PersonPreferenceController(
        IEditPersonPreference editPersonPreference, IGetPersonPreferences getPersonPreferences)
    {
        _editPersonPreference = editPersonPreference;
        this._getPersonPreferences = getPersonPreferences;
    }

    [HttpGet("/persons/{externalAuthId}/")]
    [Authorize("ReadConsumerPreferences")]
    public List<WebPersonPreferenceResponse> GetAllPersonPreferencesForPerson(string externalAuthId)
    {
        var response = _getPersonPreferences.GetPersonPreferencesForExternalId(externalAuthId);
        throw new NotImplementedException();
    }

    [HttpPost]
    [Authorize("EditConsumerPreferences")]
    public Task<List<WebPersonPreferenceResponse>> AddPersonPreference(WebPersonPreferenceRequest webPersonPreferenceRequest)
    {
        var response = _editPersonPreference.AddPersonPreference(webPersonPreferenceRequest);
        throw new NotImplementedException();
    }

    [HttpPut("{id:int}")]
    [Authorize("EditConsumerPreferences")]
    public Task<List<WebPreferenceResponse>> UpdatePersonPreference(int id)
    {
        throw new NotImplementedException();
    }
}