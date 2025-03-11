using System;
using System.Collections.Generic;

namespace CrudBS.Models;

public partial class Hospedaje
{
    public int CodigoHospedaje { get; set; }

    public int? CedulaHospedaje { get; set; }

    public DateOnly? FechaInicial { get; set; }

    public DateOnly? FechaFinal { get; set; }

    public string? CodigoReservaHospedaje { get; set; }

    public int? NumeroHabitacionHospedaje { get; set; }

    public virtual Huespede? CedulaHospedajeNavigation { get; set; }

    public virtual Reserva? CodigoReservaHospedajeNavigation { get; set; }

    public virtual Habitacione? NumeroHabitacionHospedajeNavigation { get; set; }
}
