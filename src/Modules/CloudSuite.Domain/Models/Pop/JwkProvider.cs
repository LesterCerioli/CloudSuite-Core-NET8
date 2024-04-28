using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Models.Pop
{
    public class JwkProvider
    {
        private static readonly object JsonWebKeyParameterNames;

        //public static string ComputeCanonicalJwk(RSAParameters rsaPublicKey)
        //{
            //return $@"{{""{JsonWebKeyParameterNames.E}"":""{Base64UrlHelpers.Encode(rsaPublicKey.Exponent)}"",""{JsonWebKeyParameterNames.Kty}"":""{JsonWebAlgorithmsKeyTypes.RSA}"",""{JsonWebKeyParameterNames.N}"":""{Base64UrlHelpers.Encode(rsaPublicKey.Modulus)}""}}";
        //}
    }
}
