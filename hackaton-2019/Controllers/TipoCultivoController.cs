using hackaton_2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace hackaton_2019.Controllers
{
    public class TipoCultivoController : Controller
    {
        // GET: TipoCultivo
        public ActionResult Index()
        {
            List<TipoCultivo> tipoCultivos = new List<TipoCultivo>();
            if (Session["cultivos"] != null)
            {
                tipoCultivos = (List<TipoCultivo>)Session["cultivos"];
            }
            else
            {
                tipoCultivos.Add(new TipoCultivo
                {
                    Id = 1,
                    Nombre = "Algodón"
                });
                Session["cultivos"] = tipoCultivos;
            };
            return View(tipoCultivos);           
        }
        public ActionResult AgregarTipoCultivo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarTipoCultivo(TipoCultivo tipoCultivo)
        {
            List<TipoCultivo> tipoCultivos = (List<TipoCultivo>)Session["cultivos"];
            //tipoCultivos.Add(new TipoCultivo { id = , Nombre = tipoCultivo.Nombre });
            tipoCultivo.Id = tipoCultivos.Count + 1;
            tipoCultivos.Add(tipoCultivo);

            return RedirectToAction("Index");
        }
        public ActionResult EditarTipoCultivo(int? Id)
        {
            if (Id != null)
            {
                List<TipoCultivo> conceptos = (List<TipoCultivo>)Session["cultivos"];

                return View(conceptos.Where(w => w.Id == Id.Value).FirstOrDefault());

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult EditarTipoCultivo(TipoCultivo cultivo)
        {
            List<TipoCultivo> cultivos = (List<TipoCultivo>)Session["cultivos"];

            TipoCultivo cultivoEditar = cultivos.Where(w => w.Id == cultivo.Id).FirstOrDefault();

            cultivoEditar.Nombre = cultivo.Nombre;

            return RedirectToAction("Index");
        }

        public ActionResult DeleteTipoCultivo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<TipoCultivo> cultivos = (List<TipoCultivo>)Session["cultivos"];

            TipoCultivo cultivoEliminar = cultivos.Where(w => w.Id == id.Value).FirstOrDefault();
            if (cultivoEliminar == null)
            {
                return HttpNotFound();
            }
            return View(cultivoEliminar);
        }
        // POST: /Movies/Delete/5
        [HttpPost, ActionName("DeleteTipoCultivo")]
        public ActionResult DeleteConfirmed(int id)
        {
            List<TipoCultivo> cultivos = (List<TipoCultivo>)Session["cultivos"];

            TipoCultivo cutlivoEliminar = cultivos.Where(w => w.Id == id).FirstOrDefault();
            cultivos.Remove(cutlivoEliminar);
            return RedirectToAction("Index");
        }

    }
}