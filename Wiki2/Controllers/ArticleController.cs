using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wiki2.Models;
using Wiki2.Repository;

namespace Wiki2.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        IRepository<Article> db;

        public ArticleController()
        {
            db = new ArticleRepository();
        }

        public ActionResult Index()
        {
            IEnumerable<Article> articles = db.GetArticleList();
            ViewBag.Articles = articles;
            return View(db.GetArticleList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Create(article);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        public ActionResult Edit(int id)
        {
            Article article = db.GetArticle(id);
            return View(article);
        }
        [HttpPost]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Update(article);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Article a = db.GetArticle(id);
            return View(a);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}