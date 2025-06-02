using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using sislte.Repositories;
using sislte.Services;

public class AuthorizedFilter(IStudentRepository studentRepository, IHttpContextAccessor httpContextAccessor) : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var emailClaim = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);

        if (emailClaim == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var userExists = await studentRepository.ExistsByEmailAsync(emailClaim.Value);
        if (!userExists)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        await next();
    }
}