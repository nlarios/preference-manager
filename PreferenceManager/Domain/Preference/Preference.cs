namespace PreferenceManager.Domain.Preference;

public class Preference
{
    private PreferenceId id;
    
    private Type type;

    private string value;

    private bool universal;

    private EncryptedSensitivePrefence encryptedValue;
}