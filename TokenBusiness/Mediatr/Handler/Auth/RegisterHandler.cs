using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TokenBusiness.Abstract;
using TokenBusiness.Mediatr.Command.Auth;
using TokenEntity.ReturnMessage;

namespace TokenBusiness.Mediatr.Handler.Auth
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, MediatrResult>
    {
        private readonly IAuthService _authService;

        public RegisterHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<MediatrResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var registerResult = await _authService.RegisterAsync(request.UserRegisterDto);
            return registerResult switch
            {
                > 0 => new MediatrResult((HttpStatusCode) 1000, "User registration successful.", "success"),
                0 => new MediatrResult((HttpStatusCode) 1001, "User registration failed.", "error"),
                _ => new MediatrResult((HttpStatusCode) 1001, "There is an error during registration.", "error")
            };
        }
    }
}