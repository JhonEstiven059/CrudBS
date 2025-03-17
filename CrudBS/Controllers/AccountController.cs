using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using CrudBS.Models;
using CrudBS.Models;
using System;

namespace TuProyecto.Controllers
{
    public class AccountController : Controller
    {
        private readonly CrudBsContext _context;

        public AccountController(CrudBsContext context)
        {
            _context = context;
        }

        // MÉTODO PARA MOSTRAR LA VISTA DE LOGIN
        public IActionResult Login()
        {
            return View();
        }

        // MÉTODO PARA PROCESAR EL LOGIN
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Usuarios
                    .FirstOrDefault(u => u.CorreoElectronico == model.CorreoElectronico && u.Contraseña == model.Contraseña);

                if (user != null)
                {
                    // GUARDAR DATOS EN LA SESIÓN
                    HttpContext.Session.SetString("UsarioId", user.IdUsuario.ToString());
                    HttpContext.Session.SetString("Nombre", user.Nombre);

                    return RedirectToAction("Index", "Home"); // REDIRIGIR A LA PÁGINA PRINCIPAL
                }
                else
                {
                    ViewBag.ErrorMessage = "Usuario o contraseña incorrectos";
                }
            }

            return View(model);
        }

        // CERRAR SESIÓN
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
