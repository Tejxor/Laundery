using LaunderySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaunderySystem.Services
{
    public class NewsService : BaseService
    {
        public NewsService(LaunderyContext db)
        {
            this.db = db;
        }

        public void CreateNews(News news)
        {
            db.News.Add(news);
            db.SaveChanges();
        }

        public void SaveNews(News news)
        {
            db.Entry(news).State = EntityState.Modified;
            db.SaveChanges();
        }

        public News GetNews(int? id)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                return db.News.AsNoTracking().First(c => c.Id == id);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<News> GetNewsToList()
        {
            return db.News.ToList();
        }

        public void DeleteNews(int? id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
        }

    }
}
