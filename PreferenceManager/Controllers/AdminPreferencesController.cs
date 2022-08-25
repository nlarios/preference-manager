using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PreferenceManager.Controllers;

[Authorize]
public class AdminPreferencesController : Controller
{
    private readonly ILogger _logger;

    
}