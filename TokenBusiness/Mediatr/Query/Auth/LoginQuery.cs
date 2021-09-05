using MediatR;
using TokenDAL.Security.Entity;
using TokenEntity.Dto.User;
using TokenEntity.ReturnMessage;

namespace TokenBusiness.Mediatr.Query.Auth
{
    public record LoginQuery : IRequest<MediatrResult<AccessToken>>
    {
        public LoginQuery(UserLoginDto userLoginDto)
        {
            UserLoginDto = userLoginDto;
        }
        public UserLoginDto UserLoginDto { get; }
    }
}
