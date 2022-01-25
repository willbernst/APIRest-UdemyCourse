using RESTAPIUdemyCourse.Data.VO;
using RESTAPIUdemyCourse.Model;

namespace RESTAPIUdemyCourse.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);
        TokenVO ValidateCredentials(TokenVO token);
        bool RevokeToken(string userName);
    }
}
