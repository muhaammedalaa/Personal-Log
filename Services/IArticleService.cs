namespace PersonalBlog.Services
{
    public interface IArticleService
    {
        IEnumerable<Models.Articles> GetAllArticles();
        Models.Articles? GetArticleById(int id);
        void AddArticle(Models.Articles article);
        void UpdateArticle(Models.Articles article);
        void DeleteArticle(int id);
    }
}
