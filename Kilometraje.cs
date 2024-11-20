using System;
using System.Collections.Generic;

namespace TMT_mantencion;

public partial class Kilometraje
{
    public int Id { get; set; }

    public int? DistanciaRecorrida { get; set; }

    public int? IdViaje { get; set; }

    public virtual Viaje? IdViajeNavigation { get; set; }
}
