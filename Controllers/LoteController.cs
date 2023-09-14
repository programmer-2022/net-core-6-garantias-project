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
using ProyectGarantia.Services;
using X.PagedList;

namespace ProyectGarantia.Controllers
{
    public class LoteController : Controller
    {
        public readonly IDALote DALote;
        private readonly IHTTPRequest _httpRequest;

        public LoteController(IDALote DALote, IHTTPRequest httpRequest)

        {
            this.DALote = DALote;
            _httpRequest = httpRequest;
        }

        public async Task<IActionResult> Prueba()
        {
            var informacionServicio = await _httpRequest.ObtenerMensajeAsync();
            return Ok(informacionServicio);
        }
        public IActionResult Index(int page = 1)
        {
            //var model = new DALote();
            var pageNumber = page;
            var informacionDB = DALote.GetLote();
            var Datos = informacionDB.OrderByDescending(x => x.Id).ToList().ToPagedList(pageNumber, 8);
            return View(Datos);
        }

        //Http Request
        [HttpGet("WebAppServicio")]
        public IActionResult Servicio()
        {
            var informacionServicio = _httpRequest.ObtenerMensajeAsync();
            return View(informacionServicio);
        }

        public IActionResult Create()
        {
            //var Lote=new DALote();
            //ViewBag.Lote = DALote.GetLote();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Lote Lote)
        {
            Lote.Id = 0;
            Lote.FechaCreacion = DateOnly.FromDateTime(DateTime.Now.Date);
            //var modelinsert = new DALote();
            var model = DALote.InsertLote(Lote);
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
            //var detLote = new DALote();
            var modelodetalle = DALote.GetIdLote(id);
            return View(modelodetalle);
        }

        public IActionResult Edit(int id)
        {
            //var Lote = new DALote();
            //ViewBag.Lote = DALote.GetLote();

            //var Lote = new DALote();
            var model = DALote.GetIdLote(id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Lote Lote)
        {
            //Lote.FechaModificacion = DateTime.Now;
            //var model = new DALote();
            var resultado = DALote.UpdateLote(Lote);
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
            //var LoteDelete = new DALote();
            var resultado = DALote.DeleteLote(id);
            return RedirectToAction("Index");
        }
    }
}
