﻿using TMT_mantencion.Models;

namespace TMT_mantencion;

public class MantenimientoBuses
{

    public TransporteContext context;
    public List<Bus> listaBuses { get; set; }

    public MantenimientoBuses()
    {
        context = new TransporteContext();
        listaBuses = new List<Bus>();
    }

    // Agregar Buses desde un archivo
    public void AgregarDesdeArchivo(string rutaArchivo)
    {
        int contador = 0;
        var buses = File.ReadAllLines(rutaArchivo);
        foreach (var bus in buses)
        {
            var busData = bus.Split(',');
            var busExistente = context.Buses.FirstOrDefault(b => b.Patente == busData[0]);
            if (busExistente != null)
            {
                Console.WriteLine($"El bus con patente {busData[0]} ya existe en la base de datos");
                continue;
            }
            else
            {
                Console.WriteLine($"Agregando bus con patente {busData[0]}");
            }

            if (busData.Length != 4)
            {
                Console.WriteLine($"Error al leer los datos del bus {busData[0]}");
                continue;
            }
            var busNuevo = new Bus
            {
                Patente = busData[0],
                Codigo = busData[1],
                Disponibilidad = bool.Parse(busData[2]),
                Kilometros = int.Parse(busData[3])
            };
            context.Buses.Add(busNuevo);
            contador++;
        }
        context.SaveChanges();
        if (contador > 0)
        {
            Console.WriteLine($"Se agregaron {contador} buses correctamente");
        }
        else
        {
            Console.WriteLine("No se agregaron buses");
        }
        Console.WriteLine("Presione cualquier tecla para continuar");
        Console.ReadLine();
    }

    //Listar buses
    public void ListarBuses()
    {
        listaBuses = context.Buses.ToList();
        foreach (var bus in listaBuses)
        {
            string disponibilidad = bus.Disponibilidad ? "Disponible" : "No disponible";
            Console.WriteLine($"Patente: {bus.Patente}, Código: {bus.Codigo}, Disponibilidad: {disponibilidad}");
        }
        Console.Write("Presione cualquier tecla para continuar");
        Console.ReadLine();
    }

    public void ActualizarDisponibilidad(string patente, bool disponibilidad)
    {
        var bus = context.Buses.FirstOrDefault(b => b.Patente == patente);
        if (bus != null)
        {
            if (bus.Disponibilidad == true)
            {
                Console.Write(("Actualmente el bus está disponible, ¿desea cambiar la disponibilidad? (S/N): "));
                var respuesta = Console.ReadLine();
                if (respuesta != null && respuesta == "S" || respuesta == "s")
                {
                    bus.Disponibilidad = false;
                    Console.WriteLine("El bus ahora no está disponible");
                    Console.Write("Presione cualquier tecla para continuar");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Write(("Actualmente el bus no está disponible, ¿desea cambiar la disponibilidad? (S/N): "));
                var respuesta = Console.ReadLine();
                if (respuesta != null && respuesta == "S" || respuesta == "s")
                {
                    {
                        bus.Disponibilidad = true;
                        Console.WriteLine("El bus ahora está disponible");
                        Console.Write("Presione cualquier tecla para continuar");
                        Console.ReadLine();
                    }
                }
            }
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Bus no encontrado");
            Console.Write("Presione cualquier tecla para continuar");
            Console.ReadLine();
        }
    }

    public void EliminarBus(string patente)
    {
        var bus = context.Buses.FirstOrDefault(b => b.Patente == patente);
        if (bus != null)
        {
            Console.Write("Está seguro que desea eliminar el bus " + bus.Patente + "? (s/n): ");
            var respuesta = Console.ReadLine();
            if (respuesta != null && respuesta.ToLower() == "s")
            {
                try
                {
                    context.Buses.Remove(bus);
                    context.SaveChanges();
                    Console.WriteLine("Bus eliminado correctamente");
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar el bus, verifique que no tenga viajes asociados.");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadLine();
                }
            }
        }
        else
        {
            Console.WriteLine("Bus no encontrado");
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadLine();
        }
    }
}