using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Wiki2.Models;

namespace Wiki2.Repository
{
    public class ArticleRepository : IRepository<Article>
    {
        private WikiContext db;
        private List<Article> allArticles;

        public ArticleRepository()
        {
            allArticles = new List<Article>();
            
            this.db = new WikiContext();
        }

        public IEnumerable<Article> GetArticleList()
        {
            return db.Articles;
        }

        public Article GetArticle(int id)
        {
            return db.Articles.Find(id);
        }

        public void Create(Article article)
        {
            db.Articles.Add(article);
        }

        public void Update(Article article)
        {
            db.Entry(article).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Article article = db.Articles.Find(id);
            if (article != null)
                db.Articles.Remove(article);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}