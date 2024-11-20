using System;
using System.Collections.Generic;

namespace TMT_mantencion;

public partial class Chofer
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public bool Disponibilidad { get; set; }

    public int? IdBus { get; set; }

    public virtual Bus? IdBusNavigation { get; set; }

    public virtual ICollection<Viaje> Viajes { get; } = new List<Viaje>();
}
