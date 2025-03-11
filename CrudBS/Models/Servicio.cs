using System;
using System.Collections.Generic;

namespace CrudBS.Models;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string? NombreServicio { get; set; }

    public string? Descripcion { get; set; }

    public string? Categoria { get; set; }

    public decimal? Costo { get; set; }

    public bool? Disponibilidad { get; set; }

    public string? Observacion { get; set; }

    public bool? Estado { get; set; }

    public string? TipoDeServicio { get; set; }

    public virtual ICollection<Huespede> Huespedes { get; set; } = new List<Huespede>();

    public virtual ICollection<PaquetesTuristico> PaquetesTuristicos { get; set; } = new List<PaquetesTuristico>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
