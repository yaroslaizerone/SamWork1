using System;
using System.Security.Cryptography;
using System.Text;

namespace ClassLibraryForSamWork1
{
    public class librarySHA
    {
        public string Sha(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] sourceBytePassw = Encoding.UTF8.GetBytes(password);
                byte[] hashSourseBytePassw = sha256Hash.ComputeHash(sourceBytePassw);
                string hashPassw = BitConverter.ToString(hashSourseBytePassw).Replace("-", String.Empty);
                return hashPassw;
            }

        }
    }
}
