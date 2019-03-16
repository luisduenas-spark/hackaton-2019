using hackaton_2019.Models;
using hackaton_2019.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace hackaton_2019.Controllers
{
    public class ConceptosController : Controller
    {
        // GET: Conceptos
        public ActionResult Index()
        {
            List<Concepto> conceptos = new List<Concepto>();

            if (Session["conceptos"] == null)
            {
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
            else
            {
                conceptos = (List<Concepto>)Session["conceptos"];
            }


            return View(conceptos);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Concepto concepto)
        {
            List<Concepto> conceptos = (List<Concepto>)Session["conceptos"];

            concepto.Id = conceptos.Count + 1;

            conceptos.Add(concepto);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                List<Concepto> conceptos = (List<Concepto>)Session["conceptos"];

                return View(conceptos.Where(w => w.Id == id.Value).FirstOrDefault());

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Concepto concepto)
        {
            List<Concepto> conceptos = (List<Concepto>)Session["conceptos"];

            Concepto conceptoEditar = conceptos.Where(w => w.Id == concepto.Id).FirstOrDefault();

            conceptoEditar.Nombre = concepto.Nombre;

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Concepto> conceptos = (List<Concepto>)Session["conceptos"];

            Concepto conceptoEliminar = conceptos.Where(w => w.Id == id.Value).FirstOrDefault();
            if (conceptoEliminar == null)
            {
                return HttpNotFound();
            }
            return View(conceptoEliminar);
        }
        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            List<Concepto> conceptos = (List<Concepto>)Session["conceptos"];

            Concepto conceptoEliminar = conceptos.Where(w => w.Id == id).FirstOrDefault();
            conceptos.Remove(conceptoEliminar);
            return RedirectToAction("Index");
        }
    }
}