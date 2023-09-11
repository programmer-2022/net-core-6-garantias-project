﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectGarantia.Data;
using ProyectGarantia.Models;

namespace ProyectGarantia.Controllers
{
    public class DetalleLoteController : Controller
    {
        private readonly ApplicationDbContext dbDetLote;

        public DetalleLoteController(ApplicationDbContext context)
        {
            dbDetLote = context;
        }

        // GET: DetalleLote
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = dbDetLote.DetalleLote.Include(d => d.Agencia).Include(d => d.Cliente).Include(d => d.Lote);
            
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DetalleLote/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || dbDetLote.DetalleLote == null)
            {
                return NotFound();
            }

            var detalleLote = await dbDetLote.DetalleLote
                .Include(d => d.Agencia)
                .Include(d => d.Cliente)
                .Include(d => d.Lote)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleLote == null)
            {
                return NotFound();
            }

            return View(detalleLote);
        }

        // GET: DetalleLote/Create
        public IActionResult Create()
        {
            ViewData["AgenciaId"] = new SelectList(dbDetLote.Agencia, "Id", "Nombre");
            ViewData["ClienteId"] = new SelectList(dbDetLote.Cliente, "Id", "Nombre");
            ViewData["LoteId"] = new SelectList(dbDetLote.Lote, "Id", "NumeroCorrelativo");
            return View();
        }

        // POST: DetalleLote/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LoteId,FechaOtorgada,ClienteId,AgenciaId,NombreAsesor,FechaEnvio,CantidadGarantias")] DetalleLote detalleLote)
        {
            if (ModelState.IsValid)
            {
                dbDetLote.Add(detalleLote);
                await dbDetLote.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Convierte el objeto dinámico en una lista explícita para que puedas acceder a la propiedad Count
                // Convierte los errores de validación en una lista para pasarlo a la vista
                var validationErrors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();
                ViewBag.ValidationErrorsList = validationErrors;
            }
            ViewData["AgenciaId"] = new SelectList(dbDetLote.Agencia, "Id", "Nombre", detalleLote.AgenciaId);
            ViewData["ClienteId"] = new SelectList(dbDetLote.Cliente, "Id", "Nombre", detalleLote.ClienteId);
            ViewData["LoteId"] = new SelectList(dbDetLote.Lote, "Id", "NumeroCorrelativo", detalleLote.LoteId);
            return View(detalleLote);
        }

        // GET: DetalleLote/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || dbDetLote.DetalleLote == null)
            {
                return NotFound();
            }

            var detalleLote = await dbDetLote.DetalleLote.FindAsync(id);
            if (detalleLote == null)
            {
                return NotFound();
            }
            ViewData["AgenciaId"] = new SelectList(dbDetLote.Agencia, "Id", "Nombre", detalleLote.AgenciaId);
            ViewData["ClienteId"] = new SelectList(dbDetLote.Cliente, "Id", "Nombre", detalleLote.ClienteId);
            ViewData["LoteId"] = new SelectList(dbDetLote.Lote, "Id", "NumeroCorrelativo", detalleLote.LoteId);
            return View(detalleLote);
        }

        // POST: DetalleLote/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LoteId,FechaOtorgada,ClienteId,AgenciaId,NombreAsesor,FechaEnvio,CantidadGarantias")] DetalleLote detalleLote)
        {
            if (id != detalleLote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbDetLote.Update(detalleLote);
                    await dbDetLote.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleLoteExists(detalleLote.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgenciaId"] = new SelectList(dbDetLote.Agencia, "Id", "Nombre", detalleLote.AgenciaId);
            ViewData["ClienteId"] = new SelectList(dbDetLote.Cliente, "Id", "Nombre", detalleLote.ClienteId);
            ViewData["LoteId"] = new SelectList(dbDetLote.Lote, "Id", "NumeroCorrelativo", detalleLote.LoteId);
            return View(detalleLote);
        }

        // GET: DetalleLote/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || dbDetLote.DetalleLote == null)
            {
                return NotFound();
            }

            var detalleLote = await dbDetLote.DetalleLote
                .Include(d => d.Agencia)
                .Include(d => d.Cliente)
                .Include(d => d.Lote)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleLote == null)
            {
                return NotFound();
            }

            return View(detalleLote);
        }

        // POST: DetalleLote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (dbDetLote.DetalleLote == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DetalleLote'  is null.");
            }
            var detalleLote = await dbDetLote.DetalleLote.FindAsync(id);
            if (detalleLote != null)
            {
                dbDetLote.DetalleLote.Remove(detalleLote);
            }
            
            await dbDetLote.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleLoteExists(int id)
        {
          return (dbDetLote.DetalleLote?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
