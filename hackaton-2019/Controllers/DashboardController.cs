using hackaton_2019.Models;
using hackaton_2019.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace hackaton_2019.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {

            if (Session["conceptos"] == null)
            {
                List<Concepto> conceptos = new List<Concepto>();

                conceptos.Add(new Concepto()
                {
                    Id = 1,
                    Nombre = "Riego"
                });
                conceptos.Add(new Concepto()
                {
                    Id = 2,
                    Nombre = "Fertilizante"
                });
                conceptos.Add(new Concepto()
                {
                    Id = 3,
                    Nombre = "Nómina"
                });

                Session["conceptos"] = conceptos;
            }

            if (Session["cultivos"] == null)
            {
                List<TipoCultivo> tipoCultivos = new List<TipoCultivo>();

                tipoCultivos.Add(new TipoCultivo
                {
                    Id = 1,
                    Nombre = "Algodón"
                });
                Session["cultivos"] = tipoCultivos;

                tipoCultivos.Add(new TipoCultivo
                {
                    Id = 2,
                    Nombre = "Alfalfa"
                });
                Session["cultivos"] = tipoCultivos;
            }



            string url = "http://www.fao.org/americas/noticias/rss/feed/es/?key=33";
            List<NewsResponse> news = new List<NewsResponse>();
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach (SyndicationItem item in feed.Items)
            {
                String subject = item.Title.Text;
                String summary = item.Summary.Text;

                news.Add(new NewsResponse()
                {
                    Subject = item.Title.Text,
                    Summary = item.Summary.Text
                });
            }
            ConceptosViewModel obj = new ConceptosViewModel();
            obj.NewsResponses = news.Take(10).ToList() as List<NewsResponse>;
            List<TipoCultivo> tipoCultivo = new List<TipoCultivo>();
            tipoCultivo = (List<TipoCultivo>) Session["cultivos"];
            List<Cultivo> cultivos = new List<Cultivo>();
            if (Session["superficie"] == null)
            {
                cultivos.Add(new Cultivo {
                    Id = 1,
                    TipoCultivo = tipoCultivo.Where(w => w.Id == 1).FirstOrDefault().Nombre,
                    FechaInicio = Convert.ToDateTime("2019/01/01"),
                    Nombre = "Algodón"
                });
                Session["superficie"] = cultivos;
                
            }
            else
            {
                cultivos = (List<Cultivo>)Session["superficie"];
            }
            return View(obj);
        }
        [HttpPost]
        public ActionResult Index(ConceptosViewModel cultivoVM)
        {
            List<Cultivo> cultivos = (List<Cultivo>)Session["superficie"];

            cultivoVM.Cultivos.Id = cultivos.Count + 1;
            //List<Concepto> conceptos = new List<Concepto>();
            //conceptos = (List<Concepto>)Session["conceptos"];
            //conceptoDetalle.Concepto = 

            //cultivo.Id = cultivos.Count + 1;
            cultivos.Add(cultivoVM.Cultivos);

            return RedirectToAction("Index");
        }
    }
}