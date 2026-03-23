namespace DevHub.Domain.Entities;

public sealed class Integration
{
    public Guid Id { get; private set; }
    public string Provider { get; private set; }
    public string EncryptedAccessToken { get; private set; }
    public string? EncryptedRefreshToken { get; private set; }
    public DateTime? ExpiresAt { get; private set; }

    public Integration(string provider, string encryptedAccessToken, string? encryptedRefreshToken, DateTime? expiresAt)
    {
        Id = Guid.NewGuid();
        Provider = provider;
        EncryptedAccessToken = encryptedAccessToken;
        EncryptedRefreshToken = encryptedRefreshToken;
        ExpiresAt = expiresAt;
    }
}