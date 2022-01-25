using RESTAPIUdemyCourse.Data.VO;
using RESTAPIUdemyCourse.Model;

namespace RESTAPIUdemyCourse.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
        User ValidateCredentials(string userName);
        bool RevokeToken(string userName);
        User RefreshUserInfo(User user);
    }
}
