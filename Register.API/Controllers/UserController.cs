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

    [HttpPost]
    public IActionResult Add(AddUserRequest request) => Mediator.HandleAsync<AddUserRequest, long>(request).ApiResult();

    [HttpPut("{id}")]
    public IActionResult Update(UpdateUserRequest request) => Mediator.HandleAsync(request).ApiResult();

    [HttpDelete("{id:long}")]
    public IActionResult Delete(long id) => Mediator.HandleAsync(new DeleteUserRequest(id)).ApiResult();

}

