using Microsoft.AspNetCore.Mvc;
using PreferenceManager.Model;
using PreferenceManager.UseCase.Model;

namespace PreferenceManager.Controllers;

[Route("person-preferences")]
public class PersonPreferenceController
{
    [HttpGet("/persons/{id}")]
    public async Task<List<WebPreferenceResponse>> GetAllPersonPreferencesForPerson(int id)
    {
        throw new NotImplementedException();
    }
     
    [HttpPost]
    public async Task<List<WebPreferenceResponse>> CreatePersonPreference(WebPersonPreference webPersonPreference )
    {
        throw new NotImplementedException();
    }
     
    [HttpPut("preferences/persons/{id}")]
    public async Task<List<WebPreferenceResponse>> UpdatePersonPreference(int id)
    {
        return null;
    }
}