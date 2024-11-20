using System;
using System.Collections.Generic;

namespace TMT_mantencion;

public partial class Viaje
{
    public int Id { get; set; }

    public string CiudadOrigen { get; set; } = null!;

    public string CiudadDestino { get; set; } = null!;

    public DateTime FechaInicio { get; set; }

    public DateTime? FechaTermino { get; set; }

    public int? Distancia { get; set; }

    public string? Estado { get; set; }

    public int? IdBus { get; set; }

    public int? IdChofer { get; set; }

    public virtual Bus? IdBusNavigation { get; set; }

    public virtual Chofer? IdChoferNavigation { get; set; }

    public virtual ICollection<Kilometraje> Kilometrajes { get; } = new List<Kilometraje>();
}
