using System;
using System.Collections.Generic;

namespace CrudBS.Models;

public partial class PaquetesTuristico
{
    public int IdPaquete { get; set; }

    public string? NombreServicio { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public bool? Disponibilidad { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Destino { get; set; }

    public bool? Estado { get; set; }

    public string? TipoDeViaje { get; set; }

    public int? NumeroHabitacion { get; set; }

    public int? IdServicios { get; set; }

    public virtual ICollection<Huespede> Huespedes { get; set; } = new List<Huespede>();

    public virtual Servicio? IdServiciosNavigation { get; set; }

    public virtual Habitacione? NumeroHabitacionNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
