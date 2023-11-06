using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Core.InterfaceService;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BibliotecaVirtual.Infrastructure.Autenticação
{
    public class AutenticacaoService : IServicoAutenticacao
    {
        private readonly IConfiguration _configuration;

        public AutenticacaoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string ComputarHashSha256(string password)
        {
            using (SHA256 sha256hash = SHA256.Create())
            {
                byte[] bytes = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public string GerarTokenJWT(string email, string role)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("usuario", email),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials,
                claims: claims);

            var tokenHandler = new JwtSecurityTokenHandler();

            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }
    }
}
