using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    public class FileArticleService : IArticleService
    {
        private readonly string _articlesPath;
        public FileArticleService(IWebHostEnvironment env)
        {
            _articlesPath = Path.Combine(env.ContentRootPath, "Articles");
            if (!Directory.Exists(_articlesPath))
            {
                Directory.CreateDirectory(_articlesPath);
            }
        }
        

        public IEnumerable<Articles> GetAllArticles()
        {
            var articles = new List<Articles>();
            foreach (var file in Directory.GetFiles(_articlesPath, "*.json"))
            {
                var json = File.ReadAllText(file);
                var article = System.Text.Json.JsonSerializer.Deserialize<Articles>(json);
                if (article != null)
                {
                    articles.Add(article);
                }
            }
            return articles.OrderByDescending(a=> a.PublishedDate).ToList();
        }
        public Articles? GetArticleById(int id)
        {
            var filePath = Path.Combine(_articlesPath, $"{id}.json");
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var article = System.Text.Json.JsonSerializer.Deserialize<Articles>(json);
                return article;
            }
            return null;
        }
        public void AddArticle(Articles article)
        {
            article.Id = GenerateNewId();
            var filePath = Path.Combine(_articlesPath, $"{article.Id}.json");
            var json = System.Text.Json.JsonSerializer.Serialize(article);
            File.WriteAllText(filePath, json);
        }

        private int GenerateNewId()
        {
            var existingIds = GetAllArticles().Select(a => a.Id);
            return existingIds.Any() ? existingIds.Max() + 1 : 1;
        }

        public void DeleteArticle(int id)
        {
            var filePath = Path.Combine(_articlesPath, $"{id}.json");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                throw new FileNotFoundException("Article not found.");
            }
        }

        public void UpdateArticle(Articles article)
        {
            var filePath = Path.Combine(_articlesPath, $"{article.Id}.json");
            if (File.Exists(filePath))
            {
                var json = System.Text.Json.JsonSerializer.Serialize(article);
                File.WriteAllText(filePath, json);
            }
            else
            {
                throw new FileNotFoundException("Article not found.");
            }
        }
    }
}
