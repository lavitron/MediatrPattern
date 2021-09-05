using MediatR;
using TokenEntity.Dto.User;
using TokenEntity.ReturnMessage;

namespace TokenBusiness.Mediatr.Command.Auth
{
    public record RegisterCommand : IRequest<MediatrResult>
    {
        public RegisterCommand(UserRegisterDto userRegisterDto)
        {
            UserRegisterDto = userRegisterDto;
        }

        public UserRegisterDto UserRegisterDto { get; }
    }
}