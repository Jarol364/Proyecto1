using System;

namespace caso2Programacion2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] entradasPorLocalidad = new int[3];
            int[] dineroPorLocalidad = new int[3];
            string[] nombresLocalidades = { "Sol Norte/Sur", "Sombra Este/Oeste", "Preferencial" };
            int[] preciosPorLocalidad = { 10500, 20500, 25500 };

            while (true)
            {
                Console.WriteLine("Ingrese el número de factura, o 'SALIR' para terminar:");
                string input = Console.ReadLine();
                if (input.ToUpper() == "SALIR")
                {
                    Console.WriteLine("Acá tienes tu orden:");
                    break;
                }

                Console.WriteLine("Ingrese la cédula del comprador:");
                string cedula = Console.ReadLine();
                Console.WriteLine("Ingrese el nombre del comprador:");
                string nombreComprador = Console.ReadLine();

                Console.WriteLine("Ingrese la localidad (1- Sol Norte/Sur, 2- Sombra Este/Oeste, 3- Preferencial):");
                int localidad;
                if (!int.TryParse(Console.ReadLine(), out localidad) || localidad < 1 || localidad > 3)
                {
                    Console.WriteLine("Localidad inválida. Inténtelo de nuevo.");
                    continue;
                }
                localidad -= 1;

                Console.WriteLine("Ingrese la cantidad de entradas (máximo 4):");
                int cantidadEntradas;
                if (!int.TryParse(Console.ReadLine(), out cantidadEntradas) || cantidadEntradas < 1 || cantidadEntradas > 4)
                {
                    Console.WriteLine("Cantidad de entradas inválida. Debe ser entre 1 y 4. Inténtelo de nuevo.");
                    continue;
                }
                // Calcular el subtotal y el total a pagar

                int subtotal = cantidadEntradas * preciosPorLocalidad[localidad];
                int cargosPorServicio = cantidadEntradas * 1000;
                int totalAPagar = subtotal + cargosPorServicio;

                Console.WriteLine($"El costo de cada entrada para la localidad {nombresLocalidades[localidad]} es {preciosPorLocalidad[localidad]} colones.");
                Console.WriteLine($"El monto total a pagar es {totalAPagar} colones. ¿Está de acuerdo con el monto? (si/no)");
                string confirmacion = Console.ReadLine().ToLower();

                if (confirmacion != "si")
                {
                    Console.WriteLine("Compra cancelada. Volviendo al inicio.");
                    continue;
                }

                entradasPorLocalidad[localidad] += cantidadEntradas;
                dineroPorLocalidad[localidad] += subtotal;

                // Imprimir el ticket en pantalla
                Console.WriteLine("\n=== TICKET DE COMPRA ===");
                Console.WriteLine($"Cédula: {cedula}");
                Console.WriteLine($"Nombre: {nombreComprador}");
                Console.WriteLine($"Localidad: {nombresLocalidades[localidad]}");
                Console.WriteLine($"Cantidad de Entradas: {cantidadEntradas}");
                Console.WriteLine($"Subtotal: {subtotal} colones");
                Console.WriteLine($"Cargos por Servicio: {cargosPorServicio} colones");
                Console.WriteLine($"Total a Pagar: {totalAPagar} colones");
            }

            // Mostrar estadísticas de las conpras
            Console.WriteLine("\n=== ESTADÍSTICAS DE VENTAS ===");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Cantidad Entradas Localidad {nombresLocalidades[i]}: {entradasPorLocalidad[i]}");
                Console.WriteLine($"Acumulado Dinero Localidad {nombresLocalidades[i]}: {dineroPorLocalidad[i]} colones");
            }
        }
    }
}
