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
    public class HuespedesController : Controller
    {
        private readonly CrudBsContext _context;

        public HuespedesController(CrudBsContext context)
        {
            _context = context;
        }

        // GET: Huespedes
        public async Task<IActionResult> Index()
        {
            var crudBsContext = _context.Huespedes.Include(h => h.CodigoReservaHuespedNavigation).Include(h => h.IdPaquetesTuristicosNavigation).Include(h => h.IdServiciosHuespedNavigation).Include(h => h.NumeroHabitacionHuespedNavigation);
            return View(await crudBsContext.ToListAsync());
        }

        // GET: Huespedes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huespede = await _context.Huespedes
                .Include(h => h.CodigoReservaHuespedNavigation)
                .Include(h => h.IdPaquetesTuristicosNavigation)
                .Include(h => h.IdServiciosHuespedNavigation)
                .Include(h => h.NumeroHabitacionHuespedNavigation)
                .FirstOrDefaultAsync(m => m.Cedula == id);
            if (huespede == null)
            {
                return NotFound();
            }

            return View(huespede);
        }

        // GET: Huespedes/Create
        public IActionResult Create()
        {
            ViewData["CodigoReservaHuesped"] = new SelectList(_context.Reservas, "CodigoReserva", "CodigoReserva");
            ViewData["IdPaquetesTuristicos"] = new SelectList(_context.PaquetesTuristicos, "IdPaquete", "IdPaquete");
            ViewData["IdServiciosHuesped"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio");
            ViewData["NumeroHabitacionHuesped"] = new SelectList(_context.Habitaciones, "NumeroHabitacion", "NumeroHabitacion");
            return View();
        }

        // POST: Huespedes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cedula,NumeroHabitacionHuesped,IdServiciosHuesped,IdPaquetesTuristicos,CodigoReservaHuesped,Nombre,Apellido,FechaEntrada,FechaSalida")] Huespede huespede)
        {
            if (ModelState.IsValid)
            {
                _context.Add(huespede);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoReservaHuesped"] = new SelectList(_context.Reservas, "CodigoReserva", "CodigoReserva", huespede.CodigoReservaHuesped);
            ViewData["IdPaquetesTuristicos"] = new SelectList(_context.PaquetesTuristicos, "IdPaquete", "IdPaquete", huespede.IdPaquetesTuristicos);
            ViewData["IdServiciosHuesped"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", huespede.IdServiciosHuesped);
            ViewData["NumeroHabitacionHuesped"] = new SelectList(_context.Habitaciones, "NumeroHabitacion", "NumeroHabitacion", huespede.NumeroHabitacionHuesped);
            return View(huespede);
        }

        // GET: Huespedes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huespede = await _context.Huespedes.FindAsync(id);
            if (huespede == null)
            {
                return NotFound();
            }
            ViewData["CodigoReservaHuesped"] = new SelectList(_context.Reservas, "CodigoReserva", "CodigoReserva", huespede.CodigoReservaHuesped);
            ViewData["IdPaquetesTuristicos"] = new SelectList(_context.PaquetesTuristicos, "IdPaquete", "IdPaquete", huespede.IdPaquetesTuristicos);
            ViewData["IdServiciosHuesped"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", huespede.IdServiciosHuesped);
            ViewData["NumeroHabitacionHuesped"] = new SelectList(_context.Habitaciones, "NumeroHabitacion", "NumeroHabitacion", huespede.NumeroHabitacionHuesped);
            return View(huespede);
        }

        // POST: Huespedes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cedula,NumeroHabitacionHuesped,IdServiciosHuesped,IdPaquetesTuristicos,CodigoReservaHuesped,Nombre,Apellido,FechaEntrada,FechaSalida")] Huespede huespede)
        {
            if (id != huespede.Cedula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(huespede);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HuespedeExists(huespede.Cedula))
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
            ViewData["CodigoReservaHuesped"] = new SelectList(_context.Reservas, "CodigoReserva", "CodigoReserva", huespede.CodigoReservaHuesped);
            ViewData["IdPaquetesTuristicos"] = new SelectList(_context.PaquetesTuristicos, "IdPaquete", "IdPaquete", huespede.IdPaquetesTuristicos);
            ViewData["IdServiciosHuesped"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", huespede.IdServiciosHuesped);
            ViewData["NumeroHabitacionHuesped"] = new SelectList(_context.Habitaciones, "NumeroHabitacion", "NumeroHabitacion", huespede.NumeroHabitacionHuesped);
            return View(huespede);
        }

        // GET: Huespedes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huespede = await _context.Huespedes
                .Include(h => h.CodigoReservaHuespedNavigation)
                .Include(h => h.IdPaquetesTuristicosNavigation)
                .Include(h => h.IdServiciosHuespedNavigation)
                .Include(h => h.NumeroHabitacionHuespedNavigation)
                .FirstOrDefaultAsync(m => m.Cedula == id);
            if (huespede == null)
            {
                return NotFound();
            }

            return View(huespede);
        }

        // POST: Huespedes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var huespede = await _context.Huespedes.FindAsync(id);
            if (huespede != null)
            {
                _context.Huespedes.Remove(huespede);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HuespedeExists(int id)
        {
            return _context.Huespedes.Any(e => e.Cedula == id);
        }
    }
}
