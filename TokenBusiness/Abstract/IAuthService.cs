using System.Threading.Tasks;
using TokenDAL.Security.Entity;
using TokenEntity.Dto.User;
using TokenEntity.Entity;

namespace TokenBusiness.Abstract
{
    public interface IAuthService
    {
        Task<int> RegisterAsync(UserRegisterDto userRegisterDto);
        Task<User> GetLoginUserAsync(UserLoginDto userLoginDto);

        Task<AccessToken> CreateAccessTokenAsync(User user);
        //Not need in an interface
        // Task<IEnumerable<Role>> GetUserRolesByUserIdAsync(int userId);
    }
}