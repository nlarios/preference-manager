using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreferenceManager.Domain.Person;
using PreferenceManager.Domain.Preference;
using PreferenceManager.Model;
using PreferenceManager.UseCase;
using PreferenceManager.UseCase.Model;

namespace PreferenceManager.Controllers;

[Route("/universal-preferences")]
[ApiController]
[Authorize]
public class UniversalPreferenceController : ControllerBase
{
    private readonly IGetPreferences _getPreferences;

    private readonly IEditPreference _editPreference;

    public UniversalPreferenceController(IEditPreference editPreference, IGetPreferences getPreferences)
    {
        _editPreference = editPreference;
        _getPreferences = getPreferences;
    }

    [HttpGet]
    [Authorize("ReadUniversalPreferences")]
    public List<WebPreferenceResponse> GetUniversalPreferences()
    {
        // TODO Add pagination
        var preferences = _getPreferences.GetUniversalPreferences()
            .Select(WebPreferenceMapper.MapPreferenceResponse)
            .ToList();
        return new List<WebPreferenceResponse>(preferences);
    }

    [HttpPost]
    [Authorize("EditUniversalPreferences")]
    public async Task<IActionResult> AddUniversalPreference(WebUniversalPreferenceRequest request)
    {
        var preference = await _editPreference.AddUniversalPreference(request, PersonType.ADMIN);
        return new ObjectResult(preference) {StatusCode = StatusCodes.Status201Created};
    }

    [HttpPut("{id:int}")]
    [Authorize("EditUniversalPreferences")]
    public Task<IActionResult> UpdateUniversalPreference(int id, WebUniversalPreferenceRequest request)
    {
        throw new NotImplementedException();
    }
}