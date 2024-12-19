using System.Security.Cryptography;
using System.Text;
using Security.Core.Interfaces;
using Security.Core.Services.DbContext;

namespace Security.Core.Services
{
    public class DbReadOnlySecurityService : IReadOnlySecurityService
    {
        private readonly SecurityContext _Context;

        public DbReadOnlySecurityService(SecurityContext context)
        {
            _Context = context;
        }

        public bool HasPermission(string apiKey, string permission)
        {
            throw new NotImplementedException();
        }

        public static string CreateHash(string input)
        {
            var hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));// Convert the input string to a byte array and compute the hash

            // Convert the byte array to a hexadecimal string
            StringBuilder sb = new();

            foreach (var b in hashBytes)
            {
                sb.Append(b.ToString("x2")); // "x2" formats each byte as a hexadecimal string
            }

            return sb.ToString();
        }
    }
}
