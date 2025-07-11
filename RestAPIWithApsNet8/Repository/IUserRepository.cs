using System.Runtime.CompilerServices;
using RestAPIWithApsNet8.Data.VO;
using RestAPIWithApsNet8.Model;

namespace RestAPIWithApsNet8.Repository
{
    public interface IUserRepository
    {
        User? ValidateCredentials(UserVO user);

        User? ValidateCredentials(string username);

        bool RevokeToken(string username);

        User? RefreshUserInfo(User user);
    }
}
