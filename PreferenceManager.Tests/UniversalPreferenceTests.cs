using System.Threading.Tasks;
using PreferenceManager.Domain.Person;
using PreferenceManager.Domain.Preference;
using Xunit;

namespace PreferenceManager.Tests;

public static class UniversalPreferenceTests
{
    public static void CreateUniversalPropertyOnlyAdmin()
    {
        // Given
        var personType = PersonType.ADMIN;

        // When
        var preference = Preference.CreateUniversalPreference("Test", "Testd", false,
            PreferenceType.STRING, personType);
        
        // Then
        Assert.True(preference.Universal);
    }
}