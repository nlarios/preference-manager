using System.Collections.Generic;
using PreferenceManager.Domain.Preference;
using PreferenceManager.UseCase.Model;

namespace PreferenceManager.Tests;

public static class AddPreferenceUnitTest
{
    
    public static void SolutionManagerAddPreferenceWithSolution()
    {
        // Given
        var solutionIds = new List<int>() {1, 2};
        var preferenceRequest = new WebSolutionPreferenceRequest("test", "description", 
            false, PreferenceType.BOOLEAN, solutionIds);
        // var EditPreference = new
        
    }
}