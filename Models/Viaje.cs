using System;
using System.Collections.Generic;

namespace TMT_mantencion.Models;

public partial class Viaje
{
    public int Id { get; set; }

    public int IdTramo { get; set; }

    public int IdBus { get; set; }

    public int IdChofer { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Bus IdBusNavigation { get; set; } = null!;

    public virtual Chofer IdChoferNavigation { get; set; } = null!;

    public virtual Tramo IdTramoNavigation { get; set; } = null!;
}
