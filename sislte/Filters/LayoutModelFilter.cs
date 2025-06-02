using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using sislte.Services;
using sislte.ViewModels.Layout;

public class LayoutModelFilter(IAuthService authService) : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var controller = context.Controller as Controller;
        if (controller != null)
        {
            var student = await authService.GetCurrentStudentAsync();

            if (student?.DetailedStudent != null)
            {
                controller.ViewData["LayoutModel"] = new LayoutViewModel
                {
                    FullName = student.DetailedStudent.FullName,
                    AvatarURL = student.AvatarURL,
                };
            }
        }

        await next();
    }
}