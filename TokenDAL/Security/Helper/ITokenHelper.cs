using System.Collections.Generic;
using TokenDAL.Security.Entity;
using TokenEntity.Entity;

namespace TokenDAL.Security.Helper
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, IEnumerable<Role> userRoles);
    }
}