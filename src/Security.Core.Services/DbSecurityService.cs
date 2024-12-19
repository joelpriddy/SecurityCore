using Security.Core.Interfaces;
using Security.Core.Interfaces.Enums;
using Security.Core.Services.DbContext;

namespace Security.Core.Services
{
    public class DbSecurityService : DbReadOnlySecurityService, ISecurityService
    {
        public DbSecurityService(SecurityContext context) : base(context) { }

        public string AddApiKey(string owner)
        {
            throw new NotImplementedException();
        }

        public string AddRoleToKey(string apiKey, string role)
        {
            throw new NotImplementedException();
        }

        public string AddPermissionToRole(string apiKey, string role, AccessLevel access)
        {
            throw new NotImplementedException();
        }
    }
}
