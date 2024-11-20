namespace TMT_mantencion;

public class MantenimientoBuses
{
    public TransporteContext context;
    public List<Bus> ListaBuses { get; set; }

    public MantenimientoBuses()
    {
        context = new TransporteContext();
    }

    //Agregar buses desde archivo 
    public void AgregarDesdeArchivo(string rutaArchivo)
    {
        var buses = File.ReadAllLines(rutaArchivo);
        foreach (var bus in buses)
        {
            var datos = bus.Split(",");
            var nuevoBus = new Bus
            {
                Patente = datos[0],
                Codigo = datos[1],
                Disponibilidad = bool.Parse(datos[2])
            };
            context.Buses.Add(nuevoBus);
        }
        context.SaveChanges();
    }   

    //Listar buses
    public void ListarBuses()
    {
        ListaBuses = context.Buses.ToList();
        foreach (var bus in ListaBuses)
        {
            Console.WriteLine($"Patente: {bus.Patente}, Código: {bus.Codigo}, Disponibilidad: {bus.Disponibilidad}");
        }
        Console.Write("Presione cualquier tecla para continuar");
        Console.ReadLine();
    }

    //Actualizar disponibilidad de bus
    public void ActualizarDisponibilidad(string patente, bool disponibilidad)
    {
        var bus = context.Buses.FirstOrDefault(b => b.Patente == patente);
        if(bus != null){
            if(bus.Disponibilidad == true){
                Console.Write(("Actualmente el bus está disponible, ¿desea cambiar la disponibilidad? (S/N): "));
                var respuesta = Console.ReadLine();
                if(respuesta == "S" || respuesta == "s"){
                    bus.Disponibilidad = false;
                    Console.WriteLine("El bus ahora no está disponible");
                    Console.Write("Presione cualquier tecla para continuar");
                    Console.ReadLine();
                }
            }else{
                Console.Write(("Actualmente el bus no está disponible, ¿desea cambiar la disponibilidad? (S/N): "));
                var respuesta = Console.ReadLine();
                if(respuesta == "S" || respuesta == "s"){
                    {
                        bus.Disponibilidad = true;
                        Console.WriteLine("El bus ahora está disponible");
                        Console.Write("Presione cualquier tecla para continuar");
                        Console.ReadLine();
                    }
                }
            }
            context.SaveChanges();
        }else{
            Console.WriteLine("Bus no encontrado");
            Console.Write("Presione cualquier tecla para continuar");   
            Console.ReadLine();
        }
    }

    //Eliminar bus
    public void EliminarBus(string patente)
    {
        var bus = context.Buses.FirstOrDefault(b => b.Patente == patente);
        if (bus != null){
            Console.Write("Está seguro que desea eliminar el bus " +bus.Patente+ "? (S/N): ");
            var respuesta = Console.ReadLine();
            if(respuesta == "S" || respuesta == "s"){
                context.Buses.Remove(bus);
                context.SaveChanges();
                Console.WriteLine("Bus eliminado");
                Console.WriteLine("Presione cualquier tecla para continuar");
                Console.ReadLine();
            }
        }else{
            Console.WriteLine("Bus no encontrado");
            Console.WriteLine("Presione cualquier tecla para continuar");   
            Console.ReadLine();
        }
    }
}