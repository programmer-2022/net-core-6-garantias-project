using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectGarantia.Data;
using ProyectGarantia.Data.Interfaces;
using ProyectGarantia.Models;
using X.PagedList;

namespace ProyectGarantia.Controllers
{
    public class DetalleLoteModeloController : Controller
    {
        public readonly IDALote DALote;
        public readonly IDADetalleLoteModelo DADetalleLoteModelo;

        //[Route("WebAppOpe")]

        public DetalleLoteModeloController(IDADetalleLoteModelo DADetalleLoteModelo, IDALote DALote)

        {
            this.DADetalleLoteModelo = DADetalleLoteModelo;
            this.DALote = DALote;
        }
        public IActionResult Index(int page = 1)
        {
            //var model = new DADetalleLoteModelo();
            var pageNumber = page;
            var informacionDB = DADetalleLoteModelo.GetDetalleLoteModelo();
            var Datos = informacionDB.OrderByDescending(x => x.Id).ToList().ToPagedList(pageNumber, 8);
            return View(Datos);
        }

        public IActionResult Create()
        {
            //var Lote=new DALote();
            ViewBag.Lote = DALote.GetLote();

            return View();
        }

        [HttpPost]
        public IActionResult Create(DetalleLoteModelo DetalleLoteModelo)
        {
            DetalleLoteModelo.Id = 0;
            //DetalleLoteModelo.FechaOtorgada = DateTime.Now;
            //var modelinsert = new DADetalleLoteModelo();
            var model = DADetalleLoteModelo.InsertDetalleLoteModelo(DetalleLoteModelo);
            if (model > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Details(int id)
        {
            //var detDetalleLoteModelo = new DADetalleLoteModelo();
            var modelodetalle = DADetalleLoteModelo.GetIdDetalleLoteModelo(id);
            return View(modelodetalle);
        }

        public IActionResult Edit(int id)
        {
            //var Lote = new DALote();
            ViewBag.Lote = DALote.GetLote();

            //var DetalleLoteModelo = new DADetalleLoteModelo();
            var model = DADetalleLoteModelo.GetIdDetalleLoteModelo(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(DetalleLoteModelo DetalleLoteModelo)
        {
            //DetalleLoteModelo.FechaModificacion = DateTime.Now;
            //var model = new DADetalleLoteModelo();
            var resultado = DADetalleLoteModelo.UpdateDetalleLoteModelo(DetalleLoteModelo);
            if (resultado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(resultado);
            }
        }

        public IActionResult Delete(int id)
        {
            //var DetalleLoteModeloDelete = new DADetalleLoteModelo();
            var resultado = DADetalleLoteModelo.DeleteDetalleLoteModelo(id);
            return RedirectToAction("Index");
        }
    }
}
