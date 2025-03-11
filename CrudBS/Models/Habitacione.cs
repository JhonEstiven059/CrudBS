using System;
using System.Collections.Generic;

namespace CrudBS.Models;

public partial class Habitacione
{
    public int NumeroHabitacion { get; set; }

    public string? TipoHabitacion { get; set; }

    public int? CapacidadHuespedes { get; set; }

    public bool? Estado { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Tarifa { get; set; }

    public string? Caracteristicas { get; set; }

    public virtual ICollection<Hospedaje> Hospedajes { get; set; } = new List<Hospedaje>();

    public virtual ICollection<Huespede> Huespedes { get; set; } = new List<Huespede>();

    public virtual ICollection<PaquetesTuristico> PaquetesTuristicos { get; set; } = new List<PaquetesTuristico>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
