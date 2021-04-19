using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SSP.Domain;
using SSP.Domain.AppService;
using SSP.Presentation.WebApi.Config;
using SSP.Presentation.WebApi.ViewModel;

namespace SSP.Presentation.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserAppService _userAppService;

        public LoginController(
            IMapper mapper,
            IUserAppService userAppService
        ) {
            this._mapper = mapper;
            this._userAppService = userAppService;
        }

        private object GetJwtResponse(UserDomain user, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Id.ToString(), "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString()),
                        new Claim("user_id", user.Id.ToString()),
                        new Claim("role", user.Profile.Name)
                    }
                );

            DateTime creationDate = DateTime.Now;
            DateTime expirationDate = creationDate +
                TimeSpan.FromSeconds(tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = creationDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);

            return new
            {
                authenticated = true,
                created = creationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };
        }

        [HttpPost("sign-in")]
        public IActionResult SignIn(
            [FromBody]LoginViewModel login,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations
        ) {
            bool credentialsChecked = false;
            UserDomain user = null;

            if (login != null && !String.IsNullOrWhiteSpace(login.Email)) {
                user = this._userAppService.GetUserByLogin(login.Email, login.Password);
                if (user != null) {
                    credentialsChecked = true;
                }
            }

            if (credentialsChecked) {
                return Ok(this.GetJwtResponse(user, signingConfigurations, tokenConfigurations));
            } else {
                return Unauthorized();
            }
        }
    }
}