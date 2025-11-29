using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IArticleService articleService) : base(articleService)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            var articles = _articleService.GetAllArticles();
            return View(articles);
        }
       
    }
}
