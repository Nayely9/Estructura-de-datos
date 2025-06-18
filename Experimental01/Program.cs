using System;

namespace AgendaTurnosClinica
{
    // Clase para representar un paciente 
    public class Paciente
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public Paciente(string cedula, string nombre, string telefono)
        {
            Cedula = cedula;
            Nombre = nombre;
            Telefono = telefono;
        }

        public override string ToString()
        {
            return $"{Nombre} (C.I.: {Cedula}, Tel: {Telefono})";
        }
    }

    // Clase para representar un turno 
    public class Turno
    {
        public Paciente Paciente { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }

        public Turno(Paciente paciente, string fecha, string hora)
        {
            Paciente = paciente;
            Fecha = fecha;
            Hora = hora;
        }

        public override string ToString()
        {
            return $"Paciente: {Paciente} - Fecha: {Fecha} - Hora: {Hora}";
        }
    }

    // Matriz para agendar los turnos
    public class AgendaTurnos
    {
        // Vector para fechas 
        private string[] fechas; 

        // Vector para horas 
        private string[] horas;

        // MATRIZ para almacenar los turnos
        private Turno[,] matrizTurnos;

        private int totalFechas;
        private int totalHoras;

        public AgendaTurnos(string[] fechasDisponibles, string[] horasDisponibles)
        {
            fechas = fechasDisponibles; // Vector fechas
            horas = horasDisponibles;   // Vector horas

            totalFechas = fechas.Length;
            totalHoras = horas.Length;

            matrizTurnos = new Turno[totalFechas, totalHoras]; 
        }

        public void AgregarTurno(Paciente paciente, string fecha, string hora)
        {
            int fila = Array.IndexOf(fechas, fecha);
            int columna = Array.IndexOf(horas, hora);

            if (fila == -1 || columna == -1)
            {
                Console.WriteLine("Fecha u hora no válida para el turno.");
                return;
            }

            if (matrizTurnos[fila, columna] != null)
            {
                Console.WriteLine("Ese turno ya está ocupado.");
                return;
            }

            Turno nuevoTurno = new Turno(paciente, fecha, hora);
            matrizTurnos[fila, columna] = nuevoTurno; // Se guarda el turno en la MATRIZ
            Console.WriteLine("Turno registrado exitosamente.");
        }

        // Mostrar todos los turnos en la matriz
        public void MostrarTurnos()
        {
            Console.WriteLine("\n=== Lista de Turnos en la Agenda ===");

            bool hayTurnos = false;

            for (int i = 0; i < totalFechas; i++)
            {
                for (int j = 0; j < totalHoras; j++)
                {
                    if (matrizTurnos[i, j] != null)
                    {
                        Console.WriteLine(matrizTurnos[i, j]);
                        hayTurnos = true;
                    }
                }
            }

            if (!hayTurnos)
            {
                Console.WriteLine("No hay turnos registrados.");
            }
        }

        // Buscar turno por cédula 
        public void BuscarPorCedula(string cedula)
        {
            Console.WriteLine($"\nBuscando turnos para C.I.: {cedula}");
            bool encontrado = false;

            for (int i = 0; i < totalFechas; i++)
            {
                for (int j = 0; j < totalHoras; j++)
                {
                    Turno turno = matrizTurnos[i, j];
                    if (turno != null && turno.Paciente.Cedula == cedula)
                    {
                        Console.WriteLine(turno);
                        encontrado = true;
                    }
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontraron turnos para esta cédula.");
            }
        }

        // Buscar turno por fecha 
        public void BuscarPorFecha(string fecha)
        {
            Console.WriteLine($"\nTurnos agendados para la fecha: {fecha}");
            bool encontrado = false;

            int fila = Array.IndexOf(fechas, fecha);
            if (fila == -1)
            {
                Console.WriteLine("Fecha no válida.");
                return;
            }

            for (int j = 0; j < totalHoras; j++)
            {
                Turno turno = matrizTurnos[fila, j];
                if (turno != null)
                {
                    Console.WriteLine(turno);
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No hay turnos para esta fecha.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] fechasDisponibles = new string[]
            {
                "17-06-2025", "18-06-2025", "19-06-2025", "20-06-2025", "21-06-2025"
            };

            string[] horasDisponibles = new string[]
            {
                "08:00", "09:00", "10:00", "11:00", "12:00",
                "13:00", "14:00", "15:00", "16:00", "17:00"
            };

            AgendaTurnos agenda = new AgendaTurnos(fechasDisponibles, horasDisponibles);

            string opcion;

            do
            {
                Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
                Console.WriteLine("1. Agendar turno");
                Console.WriteLine("2. Mostrar todos los turnos");
                Console.WriteLine("3. Buscar turno por cédula");
                Console.WriteLine("4. Buscar turno por fecha");
                Console.WriteLine("5. Salir");
                Console.Write("Ingrese una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Cédula del paciente: ");
                        string cedula = Console.ReadLine();

                        Console.Write("Nombre del paciente: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Teléfono del paciente: ");
                        string telefono = Console.ReadLine();

                        Console.Write("Fecha del turno (DD-MM-YYYY): ");
                        string fecha = Console.ReadLine();

                        Console.Write("Hora del turno (HH:MM): ");
                        string hora = Console.ReadLine();

                        Paciente paciente = new Paciente(cedula, nombre, telefono);
                        agenda.AgregarTurno(paciente, fecha, hora);
                        break;

                    case "2":
                        agenda.MostrarTurnos();
                        break;

                    case "3":
                        Console.Write("Ingrese la cédula a buscar: ");
                        string cedulaBuscar = Console.ReadLine();
                        agenda.BuscarPorCedula(cedulaBuscar);
                        break;

                    case "4":
                        Console.Write("Ingrese la fecha a buscar (DD-MM-YYYY): ");
                        string fechaBuscar = Console.ReadLine();
                        agenda.BuscarPorFecha(fechaBuscar);
                        break;

                    case "5":
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }

            } while (opcion != "5");
        }
    }
}
