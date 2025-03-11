using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudBS.Models;

namespace CrudBS.Controllers
{
    public class HospedajesController : Controller
    {
        private readonly CrudBsContext _context;

        public HospedajesController(CrudBsContext context)
        {
            _context = context;
        }

        // GET: Hospedajes
        public async Task<IActionResult> Index()
        {
            var crudBsContext = _context.Hospedajes.Include(h => h.CedulaHospedajeNavigation).Include(h => h.CodigoReservaHospedajeNavigation).Include(h => h.NumeroHabitacionHospedajeNavigation);
            return View(await crudBsContext.ToListAsync());
        }

        // GET: Hospedajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospedaje = await _context.Hospedajes
                .Include(h => h.CedulaHospedajeNavigation)
                .Include(h => h.CodigoReservaHospedajeNavigation)
                .Include(h => h.NumeroHabitacionHospedajeNavigation)
                .FirstOrDefaultAsync(m => m.CodigoHospedaje == id);
            if (hospedaje == null)
            {
                return NotFound();
            }

            return View(hospedaje);
        }

        // GET: Hospedajes/Create
        public IActionResult Create()
        {
            ViewData["CedulaHospedaje"] = new SelectList(_context.Huespedes, "Cedula", "Cedula");
            ViewData["CodigoReservaHospedaje"] = new SelectList(_context.Reservas, "CodigoReserva", "CodigoReserva");
            ViewData["NumeroHabitacionHospedaje"] = new SelectList(_context.Habitaciones, "NumeroHabitacion", "NumeroHabitacion");
            return View();
        }

        // POST: Hospedajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoHospedaje,CedulaHospedaje,FechaInicial,FechaFinal,CodigoReservaHospedaje,NumeroHabitacionHospedaje")] Hospedaje hospedaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hospedaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CedulaHospedaje"] = new SelectList(_context.Huespedes, "Cedula", "Cedula", hospedaje.CedulaHospedaje);
            ViewData["CodigoReservaHospedaje"] = new SelectList(_context.Reservas, "CodigoReserva", "CodigoReserva", hospedaje.CodigoReservaHospedaje);
            ViewData["NumeroHabitacionHospedaje"] = new SelectList(_context.Habitaciones, "NumeroHabitacion", "NumeroHabitacion", hospedaje.NumeroHabitacionHospedaje);
            return View(hospedaje);
        }

        // GET: Hospedajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospedaje = await _context.Hospedajes.FindAsync(id);
            if (hospedaje == null)
            {
                return NotFound();
            }
            ViewData["CedulaHospedaje"] = new SelectList(_context.Huespedes, "Cedula", "Cedula", hospedaje.CedulaHospedaje);
            ViewData["CodigoReservaHospedaje"] = new SelectList(_context.Reservas, "CodigoReserva", "CodigoReserva", hospedaje.CodigoReservaHospedaje);
            ViewData["NumeroHabitacionHospedaje"] = new SelectList(_context.Habitaciones, "NumeroHabitacion", "NumeroHabitacion", hospedaje.NumeroHabitacionHospedaje);
            return View(hospedaje);
        }

        // POST: Hospedajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoHospedaje,CedulaHospedaje,FechaInicial,FechaFinal,CodigoReservaHospedaje,NumeroHabitacionHospedaje")] Hospedaje hospedaje)
        {
            if (id != hospedaje.CodigoHospedaje)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospedaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HospedajeExists(hospedaje.CodigoHospedaje))
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
            ViewData["CedulaHospedaje"] = new SelectList(_context.Huespedes, "Cedula", "Cedula", hospedaje.CedulaHospedaje);
            ViewData["CodigoReservaHospedaje"] = new SelectList(_context.Reservas, "CodigoReserva", "CodigoReserva", hospedaje.CodigoReservaHospedaje);
            ViewData["NumeroHabitacionHospedaje"] = new SelectList(_context.Habitaciones, "NumeroHabitacion", "NumeroHabitacion", hospedaje.NumeroHabitacionHospedaje);
            return View(hospedaje);
        }

        // GET: Hospedajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospedaje = await _context.Hospedajes
                .Include(h => h.CedulaHospedajeNavigation)
                .Include(h => h.CodigoReservaHospedajeNavigation)
                .Include(h => h.NumeroHabitacionHospedajeNavigation)
                .FirstOrDefaultAsync(m => m.CodigoHospedaje == id);
            if (hospedaje == null)
            {
                return NotFound();
            }

            return View(hospedaje);
        }

        // POST: Hospedajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hospedaje = await _context.Hospedajes.FindAsync(id);
            if (hospedaje != null)
            {
                _context.Hospedajes.Remove(hospedaje);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HospedajeExists(int id)
        {
            return _context.Hospedajes.Any(e => e.CodigoHospedaje == id);
        }
    }
}
