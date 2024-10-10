using comperhensive_todo_list_api.DTO;
using comperhensive_todo_list_api.Services.Interface.General;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace comperhensive_todo_list_api.Services.Objects.General
{
    public class JwtServices : IJwtServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string CreateJwt(UserDTO user)
        {
            var issuer = "comperhensive-todo-list-api";
            var audience = "comperhensive-todo-list-react-app";
            var expirationDate = DateTime.Now.AddDays(5).ToString();
            var claims = new[]
            {
                new Claim("userName" , user.UserName),
                new Claim("userId" , user.Id.ToString()),
                new Claim("email" , user.Email),
                new Claim("name" , user.Name),
                new Claim("tokenExpirationDate" ,expirationDate) ,
                new Claim("tokenCreationDate" , DateTime.Now.ToString()),
            };

            JwtSecurityToken result = new JwtSecurityToken(issuer , audience , claims); 


            return new JwtSecurityTokenHandler().WriteToken(result);

        }

        public bool IsTokenExpired(string Jwt)
        {

            var JwtToken = new JwtSecurityToken(Jwt);


            var exprDateString = JwtToken.Claims.Where((claims) => claims.Type == "tokenExpirationDate").First().Value;
            var exprDate = DateTime.Parse(exprDateString);

            return DateTime.Now >= exprDate;

        }

        public UserDTO ReadJwt(string Jwt)
        {
            var result = new UserDTO();

            var JwtToken = new JwtSecurityToken(Jwt);

            result.Id = Guid.Parse(JwtToken.Claims.Where((Claim) => Claim.Type == "userId").First().Value);
            result.UserName = JwtToken.Claims.Where((Claim) => Claim.Type == "userName").First().Value;
            result.Name = JwtToken.Claims.Where((Claim) => Claim.Type == "name").First().Value;
            result.Email = JwtToken.Claims.Where((Claim) => Claim.Type == "email").First().Value;


            return result;
        }

        public UserDTO ReadJwt()
        {
            var Jwt = _httpContextAccessor.HttpContext.Request.Headers.Authorization;

            var result = new UserDTO();

            var JwtToken = new JwtSecurityToken(Jwt.ToString());

            result.Id = Guid.Parse(JwtToken.Claims.Where((Claim) => Claim.Type == "userId").First().Value);
            result.UserName = JwtToken.Claims.Where((Claim) => Claim.Type == "userName").First().Value;
            result.Name = JwtToken.Claims.Where((Claim) => Claim.Type == "name").First().Value;
            result.Email = JwtToken.Claims.Where((Claim) => Claim.Type == "email").First().Value;


            return result;
        }


        public Guid GetUserId() {
            var Jwt = _httpContextAccessor.HttpContext.Request.Headers.Authorization;
            var JwtToken = new JwtSecurityToken(Jwt.ToString());

            return Guid.Parse(JwtToken.Claims.Where((Claim) => Claim.Type == "userId").First().Value);
        }
    }
}
