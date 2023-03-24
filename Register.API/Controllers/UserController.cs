using DotNetCore.AspNetCore;
using DotNetCore.Objects;
using Microsoft.AspNetCore.Mvc;
using Register.Application;
using Register.Models;

namespace Register.API;

[ApiController]
[Route("api/users")]
public sealed class UserController : BaseController
{
    [HttpGet("{id}")]
    public IActionResult Get(long id) => Mediator.HandleAsync<GetUserRequest, UserModel>(new GetUserRequest(id)).ApiResult();

    [HttpGet("grid")]
    public IActionResult Grid([FromQuery] GridUserRequest request) => Mediator.HandleAsync<GridUserRequest, Grid<UserModel>>(request).ApiResult();

    [HttpGet]
    public IActionResult List() => Mediator.HandleAsync<ListUserRequest, IEnumerable<UserModel>>(new ListUserRequest()).ApiResult();

}
