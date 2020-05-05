using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki2.Repository
{
   public interface IRepository<Article> : IDisposable  
    {
        IEnumerable<Article> GetArticleList();
        Article GetArticle(int id);
        void Create(Article item);
        void Update(Article item);
        void Delete(int id);
        void Save();
    }
}
