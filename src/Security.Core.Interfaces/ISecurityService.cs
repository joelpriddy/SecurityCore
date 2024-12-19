using Security.Core.Interfaces.Enums;

namespace Security.Core.Interfaces
{
    public interface ISecurityService : IReadOnlySecurityService
    {
        string AddApiKey(string owner);
        string AddRoleToKey(string apiKey, string role);
        string AddPermissionToRole(string apiKey, string role, AccessLevel access);
    }
}
