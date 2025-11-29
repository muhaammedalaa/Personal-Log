using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PersonalBlog.Services;

namespace PersonalBlog.Controllers
{
    public class BaseController : Controller
    {
        private protected readonly IArticleService _articleService;

        public BaseController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var isAuthenticated = HttpContext.Session.GetString("IsAuthenticated");
            if (string.IsNullOrEmpty(isAuthenticated))
            {
                context.Result = RedirectToAction("Login", "Auth");
            }

            base.OnActionExecuting(context);
        }
    }
}
