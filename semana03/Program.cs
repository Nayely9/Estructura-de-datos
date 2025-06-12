using System;

namespace RegistroEstudiante
{
    //Clase que representa a un estudiante
    class Estudiante
    {
        //Propiedades del estudiante
        public int Id { get; set; }             //ID del estudiante
        public string Nombres { get; set; }     //Nombres del estudiante
        public string Apellidos { get; set; }   //Apellidos del estudiante
        public string Direccion { get; set; }   //Dirección del estudiante
        public string[] Telefonos { get; set; } //Array de 3 teléfonos

        //Constructor de la clase
        public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;
            Telefonos = telefonos;
        }

        //Método para mostrar la información del estudiante
        public void MostrarInformacion()
        {
            Console.WriteLine("\n--- INFORMACIÓN DEL ESTUDIANTE ---");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombres: {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                //Agregar una verificación para evitar mostrar teléfonos vacíos
                if (!string.IsNullOrWhiteSpace(Telefonos[i]))
                {
                    Console.WriteLine($"   Teléfono {i + 1}: {Telefonos[i]}");
                }
                else
                {
                    Console.WriteLine($"   Teléfono {i + 1}: No ingresado");
                }
            }
        }
    }

    //Clase principal
    class Program
    {
        static void Main(string[] args)
        {
            //Mensaje de inicio
            Console.WriteLine("=== REGISTRO DE ESTUDIANTE ===");

            //Solicitar ID del estudiante
            int id;
            Console.Write("Ingrese el ID: ");
            //Utilizar int.TryParse para una conversión más segura
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un número entero para el ID:");
            }

            //Solicitar nombres
            Console.Write("Ingrese los Nombres: ");
            string nombres = Console.ReadLine();

            //Solicitar apellidos
            Console.Write("Ingrese los Apellidos: ");
            string apellidos = Console.ReadLine();

            //Solicitar dirección
            Console.Write("Ingrese la Dirección: ");
            string direccion = Console.ReadLine();

            //Crear array de teléfonos y pedir al usuario que los ingrese
            string[] telefonos = new string[3];
            for (int i = 0; i < telefonos.Length; i++)
            {
                Console.Write($"Ingrese el Teléfono {i + 1}: ");
                telefonos[i] = Console.ReadLine();
            }

            //Crear un objeto de tipo Estudiante usando el metodo constructor
            Estudiante estudiante = new Estudiante(id, nombres, apellidos, direccion, telefonos);

            //Mostrar la información del estudiante en la pantalla
            estudiante.MostrarInformacion();

            //Finalizar el programa
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}