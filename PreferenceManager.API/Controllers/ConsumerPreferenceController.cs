using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreferenceManager.Model;

namespace PreferenceManager.Controllers;

[Route("consumer")]
public class ConsumerPreferencesController : ControllerBase
{
    [HttpGet("preferences/user/{id}")]
     public async Task<ICollection<WebPreference>> GetUsersUniversalPreferences(long id)
    {

        return null;
    }
    
}

