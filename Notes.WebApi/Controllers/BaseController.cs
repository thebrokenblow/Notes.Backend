using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Notes.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class BaseController : ControllerBase
{
    protected readonly IMediator _mediator;
    public Guid UserId { get; }

    public BaseController(IMediator mediator)
    {
        _mediator = mediator;

        _mediator = mediator;

        //if (User.Identity is null)
        //{
        //    throw new NullReferenceException();
        //}

        //if (!User.Identity.IsAuthenticated)
        //{
        //    UserId = Guid.Empty;
        //}
        //else
        //{
        //    var claim = User.FindFirst(ClaimTypes.NameIdentifier) 
        //        ?? throw new NullReferenceException();

        //    UserId = Guid.Parse(claim.Value);
        //}

        UserId = Guid.Empty;
    }
}