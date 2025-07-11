using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using RestAPIWithApsNet8.Configurations;
using RestAPIWithApsNet8.Data.VO;
using RestAPIWithApsNet8.Repository;
using RestAPIWithApsNet8.Services;

namespace RestAPIWithApsNet8.Business.Implementations
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd:mm:ss";
        private TokenConfiguration _configurations;
        private IUserRepository _repository;
        private readonly ITokenServices _tokenServices;

        public LoginBusinessImplementation(TokenConfiguration configurations, IUserRepository repository, ITokenServices tokenServices)
        {
            _configurations = configurations;
            _repository = repository;
            _tokenServices = tokenServices;
        }

        public TokenVO ValidateCredentials(UserVO userCredentials)
        {
            var user = _repository.ValidateCredentials(userCredentials);
            if (user == null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };
            
            var acessToken = _tokenServices.GenerateAccessToken(claims);
            var refreshToken = _tokenServices.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configurations.DaysToexpiry);

            _repository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configurations.Minutes);

            return 
                new TokenVO
                (
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                acessToken,
                refreshToken
                );
        }

        public TokenVO ValidateCredentials(TokenVO token)
        {
            var acessToken = token.Acesstokrn;
            var refreshToken = token.RefreshToken;

            var principal = _tokenServices.GetPrincipalFromExpiredToken(acessToken);

            var userName = principal.Identity.Name;

            var user = _repository.ValidateCredentials(userName);

            if (user == null || 
                user.RefreshToken != 
                refreshToken || 
                user.RefreshTokenExpiryTime <=
                DateTime.Now) return null;

            acessToken = _tokenServices.GenerateAccessToken(principal.Claims);
            refreshToken = _tokenServices.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            _repository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configurations.Minutes);

            return
                new TokenVO
                (
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                acessToken,
                refreshToken
                );
        }

        public bool RevokeToken(string userName)
        {
            return _repository.RevokeToken(userName);
        }
    }
}
