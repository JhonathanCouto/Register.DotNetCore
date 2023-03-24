using DotNetCore.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Register.API;

public abstract class BaseController : ControllerBase
{
    protected IMediator Mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();
}
