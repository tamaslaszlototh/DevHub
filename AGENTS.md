# Agent Instructions for DevHub

## Project Overview

This is a **.NET 10.0 Web API** using **Clean Architecture** with four layers:
- `DevHub.Api` - ASP.NET Core Web API (entry point)
- `DevHub.Application` - Application layer (use cases, CQRS via MediatR)
- `DevHub.Domain` - Domain layer (entities, business rules)
- `DevHub.Infrastructure` - Infrastructure layer (data access, external services)

**Package Manager:** NuGet | **Solution File:** `DevHub.slnx`

---

## Build Commands

```bash
# Build entire solution or specific project
dotnet build
dotnet build DevHub.Api/DevHub.Api.csproj
dotnet build --configuration Release

# Run the API
dotnet run --project DevHub.Api/DevHub.Api.csproj
dotnet run --urls "http://localhost:5002" --project DevHub.Api/DevHub.Api.csproj

# Clean and rebuild
dotnet clean && dotnet build
dotnet restore
```

---

## Testing Commands

**Note:** No test framework is currently configured. To add tests:

```bash
# Create a test project (use xUnit)
dotnet new xunit -n DevHub.Tests -o DevHub.Tests
dotnet slnx add DevHub.Tests/DevHub.Tests.csproj

# Run tests
dotnet test
dotnet test --filter "FullyQualifiedName~TestClassName.MethodName"  # Single test
dotnet test DevHub.Tests/DevHub.Tests.csproj
dotnet test -v n  # Verbose output
```

---

## Code Style Guidelines

### General Conventions
- **C# Version:** C# 10+ (file-scoped namespaces, record types, pattern matching)
- **Nullable:** `enable` (nullable reference types enforced)
- **Implicit Usings:** `enable` (global usings from `Microsoft.NET.Sdk`)
- **Access Modifiers:** Always specify explicitly (no `public` by default)

### Naming Conventions

| Element | Convention | Example |
|---------|-----------|---------|
| Classes/Records | PascalCase | `UserService`, `CreateUserRequest` |
| Methods/Properties | PascalCase | `GetUserById`, `UserId` |
| Parameters | camelCase | `userId`, `configuration` |
| Private fields | _camelCase | `_userRepository` |
| Interfaces | IPascalCase | `IUserRepository` |
| Files | Match class name | `UserService.cs` |

### Dependency Injection Pattern

Use **extension methods** on `IServiceCollection` for each layer:

```csharp
namespace DevHub.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomainLayerServices(this IServiceCollection services)
    {
        return services;
    }
}
```

### Error Handling

- Use **ErrorOr** library for domain-level error handling
- Return `ErrorOr<T>` from application layer services
- Validate inputs early; fail fast with descriptive errors
- Use FluentValidation for request/command validation

### CQRS with MediatR

- Commands: `IRequest<T>` for write operations
- Queries: `IRequest<T>` for read operations
- Handlers live in `Commands/` and `Queries/` folders within feature folders
- Keep handlers focused: single responsibility

### File-Scoped Namespaces

Use file-scoped namespaces (C# 10+):
```csharp
namespace DevHub.Application;

public static class DependencyInjection { }
```

### Imports

- Group imports: System namespaces first, then third-party, then project namespaces
- Remove unused imports before committing

### Documentation

Add XML documentation for public members:
```csharp
/// <summary>
/// Retrieves a user by their unique identifier.
/// </summary>
/// <param name="userId">The unique identifier of the user.</param>
/// <returns>The user if found; otherwise null.</returns>
public async Task<User?> GetUserByIdAsync(Guid userId)
```

### Property Patterns

- Use **records** for immutable DTOs: `public record UserDto(Guid Id, string Email);`
- Use **init** setters for DTOs that shouldn't mutate after creation
- Use **required** properties for mandatory constructor parameters

### Async/Await

- Always use `async`/`await` for I/O operations
- Use `Task<T>` return types; avoid `.Result` or `.Wait()`
- Name async methods with `Async` suffix: `GetUserByIdAsync`

---

## Architecture Principles

1. **Dependency Rule:** Dependencies only point inward (Api → Application → Domain → Infrastructure)
2. **Single Responsibility:** Each class/interface has one reason to change
3. **Interface Segregation:** Prefer small, focused interfaces
4. **Domain First:** Business logic belongs in the Domain layer, not in controllers
