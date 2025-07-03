using System;
using System.Collections.Generic;

// Clase que representa a un estudiante
class Estudiante
{
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Correo { get; set; }
    public double Nota { get; set; }

    // Método que permite imprimir fácilmente la información del estudiante
    public override string ToString()
    {
        return $"Cédula: {Cedula}, Nombre: {Nombre} {Apellido}, Correo: {Correo}, Nota: {Nota}";
    }
}

class Program
{
    // Lista enlazada de objetos Estudiante
    static LinkedList<Estudiante> listaEstudiantes = new LinkedList<Estudiante>();

    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine("\n--- MENÚ ---");
            Console.WriteLine("1. Agregar estudiante");
            Console.WriteLine("2. Buscar estudiante por cédula");
            Console.WriteLine("3. Eliminar estudiante");
            Console.WriteLine("4. Total estudiantes aprobados");
            Console.WriteLine("5. Total estudiantes reprobados");
            Console.WriteLine("6. Mostrar todos los estudiantes");
            Console.WriteLine("0. Salir");
            Console.Write("Ingrese una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1: AgregarEstudiante(); break;
                case 2: BuscarEstudiante(); break;
                case 3: EliminarEstudiante(); break;
                case 4: TotalAprobados(); break;
                case 5: TotalReprobados(); break;
                case 6: MostrarEstudiantes(); break;
                case 0: Console.WriteLine("Saliendo..."); break;
                default: Console.WriteLine("Opción no válida."); break;
            }

        } while (opcion != 0);
    }

    static void AgregarEstudiante()
    {
        // Crear y llenar un nuevo objeto estudiante
        Estudiante e = new Estudiante();

        Console.Write("Cédula: ");
        e.Cedula = Console.ReadLine();

        Console.Write("Nombre: ");
        e.Nombre = Console.ReadLine();

        Console.Write("Apellido: ");
        e.Apellido = Console.ReadLine();

        Console.Write("Correo: ");
        e.Correo = Console.ReadLine();

        Console.Write("Nota (1-10): ");
        e.Nota = double.Parse(Console.ReadLine());

        // Insertar el nodo por el INICIO si el estudiante está aprobado
        if (e.Nota >= 7)
        {
            // Crear un nuevo nodo y lo pone al inicio de la lista
            listaEstudiantes.AddFirst(e);
            Console.WriteLine("Estudiante aprobado agregado al inicio.");
        }
        else
        {
            // Crear un nuevo nodo y lo pone al final de la lista
            listaEstudiantes.AddLast(e);
            Console.WriteLine("Estudiante reprobado agregado al final.");
        }
    }

    static void BuscarEstudiante()
    {
        Console.Write("Ingrese la cédula a buscar: ");
        string cedula = Console.ReadLine();

        // Se recorre la lista nodo por nodo
        foreach (var est in listaEstudiantes)
        {
            if (est.Cedula == cedula)
            {
                Console.WriteLine("Estudiante encontrado:\n" + est);
                return;
            }
        }

        Console.WriteLine("Estudiante no encontrado.");
    }

    static void EliminarEstudiante()
    {
        Console.Write("Ingrese la cédula del estudiante a eliminar: ");
        string cedula = Console.ReadLine();

        // Se accede al primer nodo de la lista
        LinkedListNode<Estudiante> actual = listaEstudiantes.First;

        // Se recorre nodo por nodo usando puntero actual
        while (actual != null)
        {
            // Si el nodo actual contiene al estudiante buscado
            if (actual.Value.Cedula == cedula)
            {
                // Se elimina el nodo actual
                listaEstudiantes.Remove(actual);
                Console.WriteLine("Estudiante eliminado.");
                return;
            }

            // Avanzar al siguiente nodo
            actual = actual.Next;
        }

        Console.WriteLine("Estudiante no encontrado.");
    }

    static void TotalAprobados()
    {
        int contador = 0;

        // Recorrer todos los nodos
        foreach (var est in listaEstudiantes)
        {
            if (est.Nota >= 7)
                contador++;
        }

        Console.WriteLine("Total de estudiantes aprobados: " + contador);
    }

    static void TotalReprobados()
    {
        int contador = 0;

        // Recorrer todos los nodos
        foreach (var est in listaEstudiantes)
        {
            if (est.Nota < 7)
                contador++;
        }

        Console.WriteLine("Total de estudiantes reprobados: " + contador);
    }

    static void MostrarEstudiantes()
    {
        Console.WriteLine("\n--- Lista de Estudiantes ---");

        // Recorrer la lista nodo por nodo
        foreach (var est in listaEstudiantes)
        {
            Console.WriteLine(est);
        }
    }
}
