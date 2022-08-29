using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using Xunit.Sdk;

namespace PreferenceManager.IntegrationTests;

public class UseDatabaseAttribute : BeforeAfterTestAttribute
{
    [SuppressMessage(
        "Security",
        "CA2100:Review SQL queries for security vulnerabilities",
        Justification = "No user input, but resource stream.")]
    public override void Before(MethodInfo methodUnderTest)
    {
        DeleteDatabase();

        base.Before(methodUnderTest);
    }

    private static IEnumerable<string> ReadSchema()
    {
        return null;
    }
    
    public override void After(MethodInfo methodUnderTest)
    {
        base.After(methodUnderTest);
        DeleteDatabase();
    }

    private static void DeleteDatabase()
    {
    }
}