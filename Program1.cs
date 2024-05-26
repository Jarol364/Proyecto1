using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caso1Progra2
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            // Inicio de la lista de empleados 
            var empleados = new List<Empleado>();
            string respuesta;

            do // Bucle para solicitar datos de empleados hasta que el usuario decida salir
            {
                var empleado = SolicitarDatosEmpleado();
                empleados.Add(empleado);

                // Preguntar al usuario si desea ingresar otro empleado
                Console.Write("¿Desea ingresar otro empleado? (s/n): ");
                respuesta = Console.ReadLine();

            } while (respuesta.ToLower() == "s");

            MostrarDetallesEmpleados(empleados);

            Console.WriteLine("\nSi esta de acuerdo con los datos estos se guardaran automaticamente");
            Console.ReadLine();
        }

        static Empleado SolicitarDatosEmpleado()
        {
            Console.Write("Ingrese el número de cédula del empleado: ");
            string cedula = Console.ReadLine();

            Console.Write("Ingrese el nombre del empleado: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el tipo de empleado (1-Operario, 2-Técnico, 3-Profesional): ");
            int tipo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese la cantidad de horas laboradas: ");
            int horas = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el precio por hora: ");
            decimal precioPorHora = Convert.ToDecimal(Console.ReadLine());

            // Crear y devolver un nuevo objeto Empleado con los datos ingersados
            return new Empleado(cedula, nombre, tipo, horas, precioPorHora);
        }

        static void MostrarDetallesEmpleados(List<Empleado> empleados)
        {
            Console.WriteLine("\nDetalles de los empleados:");
            foreach (Empleado empleado in empleados)
            {
                Console.WriteLine($"Cédula: {empleado.Cedula}");
                Console.WriteLine($"Nombre Empleado: {empleado.Nombre}");
                Console.WriteLine($"Tipo Empleado: {ObtenerTipoEmpleado(empleado.Tipo)}");
                Console.WriteLine($"Salario por Hora: {empleado.PrecioPorHora}");
                Console.WriteLine($"Cantidad de Horas: {empleado.Horas}");
                Console.WriteLine($"Salario Ordinario: {empleado.CalcularSalarioOrdinario()}");
                Console.WriteLine($"Aumento: {empleado.CalcularAumento()}");
                Console.WriteLine($"Porcentaje de Aumento: {empleado.ObtenerPorcentajeAumento() * 100}%");
                Console.WriteLine($"Salario Bruto: {empleado.CalcularSalarioBruto()}");
                Console.WriteLine($"Deducción CCSS: {empleado.CalcularDeducciones()}");
                Console.WriteLine($"Salario Neto: {empleado.CalcularSalarioNeto()}");
            }
        }

        //metodo auxiliar si el tipo de empleado es 1,
        //el método devolverá "Operario"; si es 2, devolverá "Técnico"; si es 3, devolverá "Profesional";
        // y si el valor no coincide con ninguno de estos, devolverá "Desconocido"
        static string ObtenerTipoEmpleado(int tipo)
        {
            return tipo switch
            {
                1 => "Operario",
                2 => "Técnico",
                3 => "Profesional",
                _ => "Desconocido",
            };
        }
    }

    class Empleado
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public int Tipo { get; set; }
        public int Horas { get; set; }
        public decimal PrecioPorHora { get; set; }

        public Empleado(string cedula, string nombre, int tipo, int horas, decimal precioPorHora)
        {
            Cedula = cedula;
            Nombre = nombre;
            Tipo = tipo;
            Horas = horas;
            PrecioPorHora = precioPorHora;
        }

        public decimal CalcularSalarioOrdinario() => Horas * PrecioPorHora;

        public decimal CalcularAumento() => CalcularSalarioOrdinario() * ObtenerPorcentajeAumento();

        //Obtiene el porcentaje de aumento correspondiente al tipo de empleado.
        public decimal ObtenerPorcentajeAumento()
        {
            return Tipo switch
            {
                1 => 0.15m,
                2 => 0.10m,
                3 => 0.05m,
                _ => 0m,
            };
        }

        public decimal CalcularSalarioBruto() => CalcularSalarioOrdinario() + CalcularAumento();

        public decimal CalcularDeducciones() => CalcularSalarioBruto() * 0.0917m;

        public decimal CalcularSalarioNeto() => CalcularSalarioBruto() - CalcularDeducciones();
    }
}
