using ErrorOr;
using Microsoft.AspNetCore.Identity;

namespace DevHub.Domain.Entities;

public sealed class ApplicationUser : IdentityUser
{
    public string DisplayName { get; private set; }
    public Guid TenantId { get; private set; }

    private readonly List<Integration> _integrations = [];
    public IReadOnlyCollection<Integration> Integrations => _integrations.AsReadOnly();

    public ApplicationUser(string email, string displayName, Guid tenantId)
    {
        Id = Guid.NewGuid().ToString();
        Email = email;
        UserName = email;
        DisplayName = displayName;
        TenantId = tenantId;
    }

    public ErrorOr<Success> AddIntegration(Integration integration)
    {
        if (_integrations.Any(i => i.Provider == integration.Provider))
            return Error.Conflict("User.DuplicateIntegration",
                $"Integration for {integration.Provider} already exists.");

        _integrations.Add(integration);
        return Result.Success;
    }
}