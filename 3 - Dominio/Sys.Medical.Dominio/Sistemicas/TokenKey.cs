using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sys.Medical.Dominio.Sistemicas
{
    public static class TokenKey
    {
        public static string key = "rsgbni854fdss5a5a55a22z55a5@#8*hhsjakk";
        public static string Issuer = "trabalho.fiap.hackathon";
        public static string Audience = "trabalho.fiap.hackathon";


        public static string? GetToken(string nome, string codUsuario, string email, EnumTipoAcesso tipoAcesso)
        {
            
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, nome),
                    new Claim(ClaimTypes.Role, tipoAcesso.ToString()),
                    new Claim(ClaimTypes.Actor, codUsuario),
                    new Claim(ClaimTypes.Email, email)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenKey.key));
                var Issuer = Convert.ToString(TokenKey.Issuer);
                var Audience = Convert.ToString(TokenKey.Audience);

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    issuer: Issuer,
                    audience: Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(TimeSpan.FromHours(8).TotalMinutes),
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
