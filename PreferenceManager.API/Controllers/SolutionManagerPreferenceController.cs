using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreferenceManager.Domain.Person;
using PreferenceManager.UseCase;
using PreferenceManager.UseCase.Model;

namespace PreferenceManager.Controllers;

[Route("solution-manager/preferences")]
[ApiController]
public class SolutionManagerPreferencesController : ControllerBase
{
    private IAddPreference addPreference;

    public SolutionManagerPreferencesController(IAddPreference addPreference)
    {
        this.addPreference = addPreference;
    }

    [HttpPost]
    [Authorize("EditSolutionPreferences")]
    public async Task<IActionResult> AddSolutionPreference(WebSolutionPreferenceRequest request)
    {
        var preference = await addPreference.AddSolutionPreference(request, PersonType.SOLUTION_MANAGER);

        return new ObjectResult(preference) {StatusCode = StatusCodes.Status201Created};
    }
    
    [HttpPost("{id:int}")]
    [Authorize("EditSolutionPreferences")]
    public async Task<IActionResult> UpateSolutionPreference(int id, WebSolutionPreferenceRequest request)
    {
        throw new NotImplementedException();
    }
}