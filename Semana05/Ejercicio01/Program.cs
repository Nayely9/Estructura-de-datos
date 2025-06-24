//Mostrar yo estudio <asignatura> 
using System;
using System.Collections.Generic;

//Clase que representa un curso con una lista de asignaturas
class Curso
{
    public List<string> Asignaturas { get; set; }

    //Iniciar la lista de asignaturas
    public Curso()
    {
        Asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
    }

    //Método que imprime "Yo estudio <asignatura>" para cada asignatura
    public void MostrarAsignaturas()
    {
        foreach (var asignatura in Asignaturas)
        {
            Console.WriteLine($"Yo estudio {asignatura}");
        }
    }
}

class Program
{
    static void Main()
    {
        Curso curso = new Curso(); //Crear objeto curso
        curso.MostrarAsignaturas(); //Mostrar asignaturas
    }
}

