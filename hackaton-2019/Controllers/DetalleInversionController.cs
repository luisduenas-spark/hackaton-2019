using hackaton_2019.Models;
using hackaton_2019.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hackaton_2019.Controllers
{
    public class DetalleInversionController : Controller
    {
        // GET: DetalleInversion
        public ActionResult Index(int? id)
        {
            List<ConceptoDetalle> conceptoDetalles = new List<ConceptoDetalle>();
            List<Concepto> conceptos = new List<Concepto>();
            conceptos = (List<Concepto>)Session["conceptos"];
            ViewData["conceptos"] = conceptos;
            if (Session["conceptosDetalles"] == null)
            {
                conceptoDetalles.Add( new ConceptoDetalle { Id = 1, Concepto = conceptos.Where(w => w.Id == 1).FirstOrDefault().Nombre ,FechaRegistro=Convert.ToDateTime("2019/01/01"),Inversion=5000 });
                Session["conceptosDetalles"]= conceptoDetalles;
            }
            else
            {
                conceptoDetalles = (List<ConceptoDetalle>)Session["conceptosDetalles"];
            }
            ViewBag.conceptosDetalles = conceptoDetalles;
            if (id != null)
            {
                Session["selectedValue"] = id.Value;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(ConceptoDetalle conceptoDetalle)
        {
            List<ConceptoDetalle> conceptoDetalles = (List<ConceptoDetalle>)Session["conceptosDetalles"];
            //List<Concepto> conceptos = new List<Concepto>();
            //conceptos = (List<Concepto>)Session["conceptos"];
            //conceptoDetalle.Concepto = 
            conceptoDetalle.Id = conceptoDetalles.Count + 1;
            conceptoDetalles.Add(conceptoDetalle);

            return RedirectToAction("Index");
        }

        public ActionResult Cosechar()
        {
            int id = (int)Session["selectedValue"];
            List<Cultivo> cultivos = (List<Cultivo>)Session["superficie"];
            Cultivo cultivoCosechar = cultivos.Where(w => w.Id == id).FirstOrDefault();
            cultivos.Remove(cultivoCosechar);
            return RedirectToAction("Index","Dashboard");
        }
    }
}