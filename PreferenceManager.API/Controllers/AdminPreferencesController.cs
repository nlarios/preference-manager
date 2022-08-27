using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreferenceManager.Model;
using PreferenceManager.UseCase;

namespace PreferenceManager.Controllers;

[Route("admin")]
public class AdminPreferencesController : Controller
{
    
    private IGetUniversalPreferences GetUniversalPreferencesUseCase { get; }

    public AdminPreferencesController(IGetUniversalPreferences getUniversalPreferences)
    {
        GetUniversalPreferencesUseCase = getUniversalPreferences;
    }

    [HttpGet("universal-preferences")]
    [Authorize( "ReadUniversalPreferences")]
    public ICollection<WebPreference> GetUniversalPreferences()
    {
        Console.WriteLine("IM IN");
        GetUniversalPreferencesUseCase.GetPreferences();
        
        return new List<WebPreference>();
    }
    
    [HttpPost("universal-preferences")]
    [Authorize( "EditUniversalPreferences")]
    public async Task<IActionResult> CreateUniversalPreference(WebPreference request)
    {

        var preference = WebPreferenceMapper.MapPreference(request);
        
        //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        return new ObjectResult(preference) { StatusCode = StatusCodes.Status201Created };
    }
    
    [HttpPut("universal-preferences/{id}")]
    [Authorize( "EditUniversalPreferences")]
    public async Task<IActionResult> CreateUniversalPreference(long id, WebPreference request)
    {
        
        return new ObjectResult(request) { StatusCode = StatusCodes.Status201Created };
    }
    
    [HttpGet("claims")]
    public IActionResult Claims()
    {
        return Ok(User.Claims.Select(c =>
            new
            {
                c.Type,
                c.Value
            }));
    }
}