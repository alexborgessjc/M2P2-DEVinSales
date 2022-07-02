using DevInSales.Api.Estatico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DevInSales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        public record Colaborador(string Area, string Cargo);

        [HttpPost()]
        public IActionResult Post(Autenticacao autenticacao)
        {
            /* Montar autenticação do JWT */
            /* Autenticando o usuário */
                           
            var colaborador = new Colaborador("", "");

            if (autenticacao.Usuario.ToLower().Equals("admin") && autenticacao.Senha.ToLower().Equals("123"))
            {
                colaborador = new Colaborador("Administrador", "Chefe");
            }
            else if (autenticacao.Usuario.ToLower().Equals("gerente") && autenticacao.Senha.ToLower().Equals("123"))
            {
                colaborador = new Colaborador("Gerente", "GerenteDoRH");
            }
            else if (autenticacao.Usuario.ToLower().Equals("usuario") && autenticacao.Senha.ToLower().Equals("123"))
            {
                colaborador = new Colaborador("Usuario", "Funcionario");
            }
            else
            {
                return BadRequest("Credenciais incorretas!");
            }

            //var colaborador = new Colaborador("teste", "teste");

            var claimUsuario = new Claim("id", autenticacao.Usuario);
            var claimCountry = new Claim(ClaimTypes.Country, "Brasil");
            var claimCargo = new Claim("Cargo", colaborador.Cargo);
            var claimArea = new Claim(ClaimTypes.Role, colaborador.Area);

            List<Claim> listaClaims = new List<Claim>();
            listaClaims.Add(claimUsuario);
            listaClaims.Add(claimCountry);
            listaClaims.Add(claimCargo);
            listaClaims.Add(claimArea);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            SecurityTokenDescriptor securityTokenDescriptor = new();
            securityTokenDescriptor.Subject = new ClaimsIdentity(listaClaims);
            securityTokenDescriptor.Expires = DateTime.UtcNow.AddDays(1);
            securityTokenDescriptor.Issuer = JWTConfiguracaoAppsetings.Issuer;
            securityTokenDescriptor.Audience = JWTConfiguracaoAppsetings.Audience;

            /* Chave Simetrica */
            SymmetricSecurityKey symmetricSecurityKey = new(JWTConfiguracaoAppsetings.Key);

            securityTokenDescriptor.SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenCriado = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var tokenNoFormatoString = jwtSecurityTokenHandler.WriteToken(tokenCriado);

            return Ok(tokenNoFormatoString);
        }
    }
}
