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
    public class ReservasController : Controller
    {
        private readonly CrudBsContext _context;

        public ReservasController(CrudBsContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var crudBsContext = _context.Reservas.Include(r => r.IdPaquetesReservaNavigation).Include(r => r.IdServiciosReservaNavigation).Include(r => r.IdUsuarioNavigation).Include(r => r.NumeroHabitacionReservaNavigation);
            return View(await crudBsContext.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.IdPaquetesReservaNavigation)
                .Include(r => r.IdServiciosReservaNavigation)
                .Include(r => r.IdUsuarioNavigation)
                .Include(r => r.NumeroHabitacionReservaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewData["IdPaquetesReserva"] = new SelectList(_context.PaquetesTuristicos, "IdPaquete", "IdPaquete");
            ViewData["IdServiciosReserva"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            ViewData["NumeroHabitacionReserva"] = new SelectList(_context.Habitaciones, "NumeroHabitacion", "NumeroHabitacion");
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoReserva,IdServiciosReserva,IdPaquetesReserva,IdUsuario,NumeroHabitacionReserva,FechaInicial,FechaFinal,NumeroPersonas,Valor,Anticipo,FechaReserva,Estado")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPaquetesReserva"] = new SelectList(_context.PaquetesTuristicos, "IdPaquete", "IdPaquete", reserva.IdPaquetesReserva);
            ViewData["IdServiciosReserva"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", reserva.IdServiciosReserva);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", reserva.IdUsuario);
            ViewData["NumeroHabitacionReserva"] = new SelectList(_context.Habitaciones, "NumeroHabitacion", "NumeroHabitacion", reserva.NumeroHabitacionReserva);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["IdPaquetesReserva"] = new SelectList(_context.PaquetesTuristicos, "IdPaquete", "IdPaquete", reserva.IdPaquetesReserva);
            ViewData["IdServiciosReserva"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", reserva.IdServiciosReserva);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", reserva.IdUsuario);
            ViewData["NumeroHabitacionReserva"] = new SelectList(_context.Habitaciones, "NumeroHabitacion", "NumeroHabitacion", reserva.NumeroHabitacionReserva);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodigoReserva,IdServiciosReserva,IdPaquetesReserva,IdUsuario,NumeroHabitacionReserva,FechaInicial,FechaFinal,NumeroPersonas,Valor,Anticipo,FechaReserva,Estado")] Reserva reserva)
        {
            if (id != reserva.CodigoReserva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.CodigoReserva))
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
            ViewData["IdPaquetesReserva"] = new SelectList(_context.PaquetesTuristicos, "IdPaquete", "IdPaquete", reserva.IdPaquetesReserva);
            ViewData["IdServiciosReserva"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", reserva.IdServiciosReserva);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", reserva.IdUsuario);
            ViewData["NumeroHabitacionReserva"] = new SelectList(_context.Habitaciones, "NumeroHabitacion", "NumeroHabitacion", reserva.NumeroHabitacionReserva);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.IdPaquetesReservaNavigation)
                .Include(r => r.IdServiciosReservaNavigation)
                .Include(r => r.IdUsuarioNavigation)
                .Include(r => r.NumeroHabitacionReservaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(string id)
        {
            return _context.Reservas.Any(e => e.CodigoReserva == id);
        }
    }
}
