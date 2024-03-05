using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Services.Catalog.BusinessLogic.Abstractions;
using Shop.Services.Catalog.WebAPI.Constants;
using Shop.Services.Catalog.WebAPI.Dtos;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Shop.Services.Catalog.WebAPI.Controllers;

[Authorize]
[ApiController]
[Produces(ApiConstants.ContentType)]
[Route(ApiConstants.ControllerName)] // Add controller name
[ProducesResponseType(Status400BadRequest, Type = typeof(ErrorDto))]
[ProducesResponseType(Status401Unauthorized, Type = typeof(ErrorDto))]
[ProducesResponseType(Status404NotFound, Type = typeof(ErrorDto))]
[ProducesResponseType(Status500InternalServerError, Type = typeof(ErrorDto))]
public class Controller : ControllerBase
{
    private readonly IService _service;

    public Controller(IService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(Status201Created, Type = typeof(object))]
    public async Task<ActionResult<object>> Create(CancellationToken ct)
        => await _service.Create(ct);
}