using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ApiKeyHasher
    {
        // Method to convert an API key to a hashed integer
        public static int ConvertToInt(string apiKey)
        {
            using (var sha256 = SHA256.Create())
            {
                // Compute the hash for the provided API key
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(apiKey));
                // Convert the first 4 bytes of the hash to an integer
                int hashInt = BitConverter.ToInt32(hashBytes, 0);
                return hashInt;
            }
        }
    }
}
