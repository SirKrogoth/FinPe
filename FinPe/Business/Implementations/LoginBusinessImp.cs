using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using FinPe.Model;
using FinPe.Repository;
using FinPe.Security.Configuration;

namespace FinPe.Business.Implementations
{
    public class LoginBusinessImp : ILoginBusiness
    {
        private ILoginRepository _repository;

        private SigningConfiguration _signingConfiguration;
        private TokenConfiguration _tokenConfiguration;

        public LoginBusinessImp(ILoginRepository repository, SigningConfiguration signingConfiguration, 
            TokenConfiguration tokenConfiguration)
        {
            _repository = repository;
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
        }

        public object BuscarPorLogin(Login usuarioLogin)
        {
            bool credencialValida = false;

            if(usuarioLogin != null && !string.IsNullOrEmpty(usuarioLogin.login))
            {
                var baseUsuario = _repository.BuscarPorLogin(usuarioLogin.login);

                credencialValida = ((baseUsuario != null) && (usuarioLogin.login == baseUsuario.login) && (BCrypt.Net.BCrypt.Verify(usuarioLogin.senha,baseUsuario.senha)));
            }

            if(credencialValida == true)
            {
                //Criação do TOKEN
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                    new GenericIdentity(usuarioLogin.login, "login"),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuarioLogin.login),
                    }
                );

                //Horario em que está iniciando a nova sessão
                DateTime dataCriacao = DateTime.Now;
                //Horario em que irá se expirar a sessao
                DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();
                string token = CriarToken(claimsIdentity, dataCriacao, dataExpiracao, handler);

                return Sucesso(dataCriacao, dataExpiracao, token);
            }
            else
            {
                return SemSucesso();
            }
        }

        private object SemSucesso()
        {
            return new
            {
                autenticated = false,
                message = "Falha na autenticação"
            };
        }

        private object Sucesso(DateTime dataCriacao, DateTime dataExpiracao, string token)
        {
            return new
            {
                autenticated = true,
                created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };
        }

        private string CriarToken(ClaimsIdentity claimsIdentity, DateTime dataCriacao, DateTime dataExpiracao, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SignatureCredentials,
                Subject = claimsIdentity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }
    }
}