using System;
using System.Collections.Generic;

namespace TMT_mantencion.Models;

public partial class Chofer
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public bool Disponibilidad { get; set; }

    public int Kilometros { get; set; }

    public virtual ICollection<Viaje> Viajes { get; } = new List<Viaje>();
}
