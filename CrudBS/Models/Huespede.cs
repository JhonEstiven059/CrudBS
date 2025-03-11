using System;
using System.Collections.Generic;

namespace CrudBS.Models;

public partial class Huespede
{
    public int Cedula { get; set; }

    public int? NumeroHabitacionHuesped { get; set; }

    public int? IdServiciosHuesped { get; set; }

    public int? IdPaquetesTuristicos { get; set; }

    public string? CodigoReservaHuesped { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateOnly? FechaEntrada { get; set; }

    public DateOnly? FechaSalida { get; set; }

    public virtual Reserva? CodigoReservaHuespedNavigation { get; set; }

    public virtual ICollection<Hospedaje> Hospedajes { get; set; } = new List<Hospedaje>();

    public virtual PaquetesTuristico? IdPaquetesTuristicosNavigation { get; set; }

    public virtual Servicio? IdServiciosHuespedNavigation { get; set; }

    public virtual Habitacione? NumeroHabitacionHuespedNavigation { get; set; }
}
