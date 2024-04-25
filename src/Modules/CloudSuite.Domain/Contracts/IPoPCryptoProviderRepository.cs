using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Domain.Contracts
{
    public interface IPoPCryptoProviderRepository
    {
        /// <summary>
        /// Obtém a representação canônica da chave pública em formato JWK.
        /// </summary>
        Task<string> GetCannonicalPublicKeyJwkAsync();

        /// <summary>
        /// Obtém o algoritmo criptográfico usado para assinar.
        /// </summary>
        Task<string> GetCryptographicAlgorithmAsync();

        /// <summary>
        /// Assina um payload com a chave privada e retorna o resultado da assinatura.
        /// </summary>
        /// <param name="payload">Dados que serão assinados.</param>
        /// <returns>Array de bytes representando a assinatura do payload.</returns>
        Task<byte[]> SignAsync(byte[] payload);
    }
}

