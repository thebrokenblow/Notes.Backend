using Notes.Application.Interfaces;
using System.Security.Claims;

namespace Notes.WebApi.Services;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    public Guid UserId
    {
        get
        {
            var id = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(id))
            {
                return Guid.Empty;
            }

            return Guid.Parse(id);
        }
    }
}