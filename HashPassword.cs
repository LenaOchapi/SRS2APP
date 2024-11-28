using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
namespace SRS2APP
{
    public class HashPassword
    {
        public string Hash(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] sourceBytePassword = Encoding.UTF8.GetBytes(password);
                byte[] hashSourceBytePassw = sha256Hash.ComputeHash(sourceBytePassword);
                string hadhPassw = BitConverter.ToString(hashSourceBytePassw).Replace("-", String.Empty);
                return hadhPassw;
            }
        }
    }
}
