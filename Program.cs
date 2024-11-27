
using TMT_mantencion;
var mantenimientoBuses = new MantenimientoBuses();
var opcion = 0;

while (true)
{
    Console.WriteLine("\nSistema de Mantenimiento de Buses");
    Console.WriteLine("1. Agregar buses desde archivo");
    Console.WriteLine("2. Listar buses");
    Console.WriteLine("3. Actualizar disponibilidad de bus");
    Console.WriteLine("4. Eliminar bus");
    Console.WriteLine("5. Salir");
    Console.Write("Ingrese una opción: ");
    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            Console.Write("Ingrese la ruta del archivo: ");
            var rutaArchivo = Console.ReadLine();
            try
            {
                if (!File.Exists(rutaArchivo))
                {
                    Console.WriteLine("El archivo no existe");
                }
                else
                {
                    mantenimientoBuses.AgregarDesdeArchivo(rutaArchivo);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            break;
        case 2:
            mantenimientoBuses.ListarBuses();
            break;
        case 3:
            Console.Write("Ingrese la patente del bus: ");
            var patente = Console.ReadLine();
            mantenimientoBuses.ActualizarDisponibilidad(patente, true);
            break;
        case 4:
            Console.Write("Ingrese la patente del bus: ");
            var patenteEliminar = Console.ReadLine();
            mantenimientoBuses.EliminarBus(patenteEliminar);
            break;
        case 5:
            return;
        default:
            Console.WriteLine("Opción inválida");
            break;
    }
}
