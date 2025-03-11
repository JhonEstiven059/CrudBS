using System;
using System.Collections.Generic;

namespace CrudBS.Models;

public partial class Role
{
    public int IdRol { get; set; }

    public string? Nombre { get; set; }

    public bool? Estado { get; set; }

    public string? IdPermisos { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    public int? NumUsuarios { get; set; }

    public virtual Permiso? IdPermisosNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
