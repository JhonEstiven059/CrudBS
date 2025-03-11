using System;
using System.Collections.Generic;

namespace CrudBS.Models;

public partial class Reserva
{
    public string CodigoReserva { get; set; } = null!;

    public int? IdServiciosReserva { get; set; }

    public int? IdPaquetesReserva { get; set; }

    public string? IdUsuario { get; set; }

    public int? NumeroHabitacionReserva { get; set; }

    public DateOnly? FechaInicial { get; set; }

    public DateOnly? FechaFinal { get; set; }

    public int? NumeroPersonas { get; set; }

    public decimal? Valor { get; set; }

    public decimal? Anticipo { get; set; }

    public DateOnly? FechaReserva { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Hospedaje> Hospedajes { get; set; } = new List<Hospedaje>();

    public virtual ICollection<Huespede> Huespedes { get; set; } = new List<Huespede>();

    public virtual PaquetesTuristico? IdPaquetesReservaNavigation { get; set; }

    public virtual Servicio? IdServiciosReservaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual Habitacione? NumeroHabitacionReservaNavigation { get; set; }
}
