using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models.Pop
{
    public class RsaKeyManager
    {
        public static RSA CreateRsaKey(int keySize)
        {
            var rsa = RSA.Create();
            rsa.KeySize = keySize;
            return rsa;
        }
    }
}
