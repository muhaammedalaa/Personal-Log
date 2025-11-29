using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Services;

namespace PersonalBlog.Controllers
{
    public class ArticleController : BaseController
    {
        public ArticleController(IArticleService articleService) : base(articleService)
        {
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var article = _articleService.GetArticleById(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        
    }
}
