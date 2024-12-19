namespace Security.Core.Interfaces
{
    public interface IReadOnlySecurityService
    {
        bool HasPermission(string apiKey, string permission);
    }
}
