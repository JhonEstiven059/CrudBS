using System;
using System.Collections.Generic;

namespace CrudBS.Models;

public partial class Usuario
{
    public string IdUsuario { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Contraseña { get; set; }

    public int? IdRol { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    public bool? Estado { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public virtual Role? IdRolNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
