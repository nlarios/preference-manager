using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreferenceManager.Domain.Person;
using PreferenceManager.Domain.Preference;
using PreferenceManager.Model;
using PreferenceManager.UseCase;
using PreferenceManager.UseCase.Model;

namespace PreferenceManager.Controllers;

[Route("admin/universal-preferences")]
[ApiController]
public class AdminPreferenceController : ControllerBase
{
    private IGetPreferences getPreferences;

    private IAddPreference addPreference;

    public AdminPreferenceController(IAddPreference addPreference, IGetPreferences getPreferences)
    {
        this.addPreference = addPreference;
        this.getPreferences = getPreferences;
    }

    [HttpGet]
    [Authorize("ReadUniversalPreferences")]
    public List<WebPreferenceResponse> GetUniversalPreferences()
    {
        // TODO Add pagination
        var preferences = getPreferences.GetUniversalPreferences()
            .Select(WebPreferenceMapper.MapPreferenceResponse)
            .ToList();
        return new List<WebPreferenceResponse>(preferences);
    }

    [HttpPost]
    [Authorize("EditUniversalPreferences")]
    public async Task<IActionResult> AddUniversalPreference(WebUniversalPreferenceRequest request)
    {

        var preference = await addPreference.AddUniversalPreference(request, PersonType.ADMIN);
        
        return new ObjectResult(preference) {StatusCode = StatusCodes.Status201Created};
    }

    [HttpPut("universal-preferences/{id:int}")]
    [Authorize("EditUniversalPreferences")]
    public async Task<IActionResult> UpdateUniversalPreference(int id, WebUniversalPreferenceRequest request)
    {
        return new ObjectResult(request) {StatusCode = StatusCodes.Status200OK};
    }
}