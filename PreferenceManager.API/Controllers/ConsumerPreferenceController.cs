using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PreferenceManager.Model;

namespace PreferenceManager.Controllers;

[Route("consumer")]
public class ConsumerPreferencesController : ControllerBase
{
    [HttpGet("universal-preferences")]
    public async Task<List<WebPreferenceResponse>> GetUniversalPreferences()
    {
    
        return null;
    }
    
    [HttpGet("preferences/solutions/{id}")]
    public async Task<List<WebPreferenceResponse>> GetAvailablePreferencesForSolution(int id)
    {

        return null;
    }
    
    [HttpGet("universal-preferences/persons/{id}")]
     public async Task<List<WebPreferenceResponse>> GetUniversalPersonPreferences(int id)
    {
    
        return null;
    }
   
}

