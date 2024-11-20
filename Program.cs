
using TMT_mantencion;

class Program
{
    static void Main(string[] args)
    {
        var mantenimientoBuses = new MantenimientoBuses();
        while (true){
            Console.WriteLine("\nSistema de Mantenimiento de Buses");
            Console.WriteLine("1. Agregar buses desde archivo");
            Console.WriteLine("2. Listar buses");
            Console.WriteLine("3. Actualizar disponibilidad de bus");
            Console.WriteLine("4. Eliminar bus");
            Console.WriteLine("5. Salir");
            Console.Write("Ingrese una opción: ");
            var opcion = Console.ReadLine();

            switch(opcion){
                case "1":
                    Console.Write("Ingrese la ruta del archivo: ");
                    var rutaArchivo = Console.ReadLine();
                    mantenimientoBuses.AgregarDesdeArchivo(rutaArchivo);
                    break;
                case "2":
                    mantenimientoBuses.ListarBuses();
                    break;
                case "3":
                    Console.Write("Ingrese la patente del bus: ");
                    var patente = Console.ReadLine();
                    mantenimientoBuses.ActualizarDisponibilidad(patente, true);
                    break;
                case "4":
                    Console.Write("Ingrese la patente del bus: ");
                    var patenteEliminar = Console.ReadLine();
                    mantenimientoBuses.EliminarBus(patenteEliminar);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción inválida");
                    break;
            }
        }
    }
}