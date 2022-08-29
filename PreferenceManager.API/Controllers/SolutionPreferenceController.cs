using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreferenceManager.Domain.Person;
using PreferenceManager.Model;
using PreferenceManager.UseCase;
using PreferenceManager.UseCase.Model;

namespace PreferenceManager.Controllers;

[Route("solution-preferences")]
[ApiController]
[Authorize]
public class SolutionManagerPreferencesController : ControllerBase
{
    private readonly IEditPreference _editPreference;

    public SolutionManagerPreferencesController(IEditPreference editPreference)
    {
        _editPreference = editPreference;
    }

    [HttpPost]
    [Authorize("EditSolutionPreferences")]
    public async Task<IActionResult> AddSolutionPreference(WebSolutionPreferenceRequest request)
    {
        var preference = await _editPreference.AddSolutionPreference(request, PersonType.SOLUTION_MANAGER);

        return new ObjectResult(preference) {StatusCode = StatusCodes.Status201Created};
    }
    
    [HttpPost("{id:int}")]
    [Authorize("EditSolutionPreferences")]
    public Task<IActionResult> UpdateSolutionPreference(int id, WebSolutionPreferenceRequest request)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("solutions/{id}")]
    [Authorize("ReadSolutionPreferences")]
    public async Task<List<WebPreferenceResponse>> GetAvailablePreferencesForSolution(int id)
    {
        throw new NotImplementedException();
    }
}