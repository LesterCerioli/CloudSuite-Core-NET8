using CloudSuite.Modules.Application.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Modules.Application.Services.Implementations
{
    public class TokenAppService : ITokenAppService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TokenAppService> _logger;
        private readonly RsaSecurityKey _rsaSecurityKey;

        public TokenAppService(IConfiguration configuration, ILogger<TokenAppService> logger)
        {
            _configuration = configuration;
            _logger = logger;

            _configuration = configuration;
            _logger = logger;

            // Load the RSA private key from configuration
            string privateKey = _configuration["Jwt:PrivateKey"];
            RSA rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out _);
            _rsaSecurityKey = new RsaSecurityKey(rsa);

        }

        public async Task<string> GenerateTokenAsync(string username)
        {
            try
            {
                var credentials = new SigningCredentials(_rsaSecurityKey, SecurityAlgorithms.RsaSha256);
                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: new[] { new Claim(ClaimTypes.Name, username) },
                    expires: DateTime.Now.AddMinutes(30), // Token expiration time (30 minutes)
                    signingCredentials: credentials
                );
                return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao gerar token JWT para usuário {Username}", username);
                throw; // Re-throw to allow error handling at the higher level

            }
        }
    }
}
