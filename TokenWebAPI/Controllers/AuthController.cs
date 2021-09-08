using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TokenBusiness.Mediatr.Command.Auth;
using TokenBusiness.Mediatr.Query.Auth;
using TokenEntity.Dto.User;

namespace TokenWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> LoginAsync(UserLoginDto userLoginDto)
        {
            try
            {
                var query = new LoginQuery(userLoginDto);
                var result = await _mediator.Send(query);
                return result.Item == null
                    ? Ok(new {code = result.StatusCode, message = result.Message, type = result.ResultType})
                    : Ok(new
                    {
                        code = result.StatusCode, message = result.Message, result.Item, type = result.ResultType
                    });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.InnerException);
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> RegisterAsync(UserRegisterDto userRegisterDto)
        {
            try
            {
                var command = new RegisterCommand(userRegisterDto);
                var result = await _mediator.Send(command);
                return Ok(new {code = result.StatusCode, message = result.Message, type = result.ResultType});
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.InnerException);
            }
        }
    }
}