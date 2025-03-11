using System;
using System.Collections.Generic;

namespace CrudBS.Models;

public partial class Permiso
{
    public string Id { get; set; } = null!;

    public string? Accion { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
