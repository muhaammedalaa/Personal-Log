using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Services;

namespace PersonalBlog.Controllers
{
    public class AdminController : BaseController
    {
        public AdminController(IArticleService articleService) : base(articleService)
        {
        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            var articles = _articleService.GetAllArticles();
            return View(articles);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Models.Articles article)
        {
            if (ModelState.IsValid)
            {
                article.PublishedDate = DateTime.Now;
                _articleService.AddArticle(article);
                return RedirectToAction("Dashboard");
            }
            return View(article);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var article = _articleService.GetArticleById(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }
        [HttpPost]
        public IActionResult Edit(Models.Articles article)
        {
            if (ModelState.IsValid)
            {
                _articleService.UpdateArticle(article);
                return RedirectToAction("Dashboard");
            }
            return View(article);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var article = _articleService.GetArticleById(id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _articleService.DeleteArticle(id);
            return RedirectToAction("Dashboard");

        }

    
         
       
    }
}
