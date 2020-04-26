using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace Nethereum.Metamask.Blazor.Server.Classes
{
    public class ShaHash
    {
        private SHA256 Sha256 = SHA256.Create();

        private byte[] GetHashSha256(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                return Sha256.ComputeHash(stream);
            }
        }

        public string BytesToString(string filename)
        {
            byte[] bytes = GetHashSha256(filename);

            string result = "";
            foreach (byte b in bytes)
            {
                result += b.ToString("x2");
            }
            return result;
        }
    }
}
