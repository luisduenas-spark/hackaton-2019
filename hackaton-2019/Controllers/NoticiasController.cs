using hackaton_2019.Models;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using System.Xml;

namespace hackaton_2019.Controllers
{
    public class NoticiasController : Controller
    {
        // GET: Noticias
        public List<NewsResponse> Index()
        {
            string url = "http://www.fao.org/americas/noticias/rss/feed/es/?key=33";
            List<NewsResponse> news = new List<NewsResponse>();
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach (SyndicationItem item in feed.Items)
            {
                String subject = item.Title.Text;
                String summary = item.Summary.Text;

                news.Add(new NewsResponse() {
                    Subject = item.Title.Text,
                    Summary = item.Summary.Text
                });
            }
            return news;
        }
    }
}