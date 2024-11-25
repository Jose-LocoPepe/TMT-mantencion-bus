using System;
using System.Collections.Generic;

namespace TMT_mantencion.Models;

public partial class Bus
{
    public int Id { get; set; }

    public string Patente { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public bool Disponibilidad { get; set; }

    public int Kilometros { get; set; }

    public virtual ICollection<Viaje> Viajes { get; } = new List<Viaje>();
}
