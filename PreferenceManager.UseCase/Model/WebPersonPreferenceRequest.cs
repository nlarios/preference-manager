namespace PreferenceManager.UseCase.Model;

public class WebPersonPreferenceRequest
{
    public string ExternalAuthId { get; }
    public int PreferenceId { get; }
    public string Content { get; }
    public string? EncryptedKey { get; }

    public WebPersonPreferenceRequest(string externalAuthId, int preferenceId, string content, string? encryptedKey)
    {
        ExternalAuthId = externalAuthId;
        PreferenceId = preferenceId;
        Content = content;
        EncryptedKey = encryptedKey;
    }
}