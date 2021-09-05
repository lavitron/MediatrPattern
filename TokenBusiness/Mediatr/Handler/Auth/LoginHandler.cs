using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TokenBusiness.Abstract;
using TokenBusiness.Mediatr.Query.Auth;
using TokenDAL.Security.Entity;
using TokenEntity.ReturnMessage;

namespace TokenBusiness.Mediatr.Handler.Auth
{
    public class LoginHandler : IRequestHandler<LoginQuery, MediatrResult<AccessToken>>
    {
        private readonly IAuthService _authService;

        public LoginHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<MediatrResult<AccessToken>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await _authService.GetLoginUserAsync(request.UserLoginDto);

            if (currentUser == null)
                return new MediatrResult<AccessToken>((HttpStatusCode) 1001, "User not found", null, "error");
            if (currentUser.Name == null)
                return new MediatrResult<AccessToken>((HttpStatusCode) 1001, "Password is wrong", null, "error");

            var accessToken = await _authService.CreateAccessTokenAsync(currentUser);

            return accessToken == null
                ? new MediatrResult<AccessToken>((HttpStatusCode) 1001,
                    "There was an error during creating access token", null, "error")
                : new MediatrResult<AccessToken>((HttpStatusCode) 1000, "Login successful", accessToken, "success");
        }
    }
}