//Notas por asignaturas 
using System;
using System.Collections.Generic;

// Clase que representa un curso con asignaturas y notas
class Curso
{
    public List<string> Asignaturas { get; set; }
    public Dictionary<string, double> Notas { get; set; }

    //Inicializamos las asignaturas y el diccionario de notas
    public Curso()
    {
        Asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
        Notas = new Dictionary<string, double>();
    }

    //Método que solicita al usuario la nota de cada asignatura
    public void IngresarNotas()
    {
        foreach (var asignatura in Asignaturas)
        {
            Console.Write($"Ingrese la nota de {asignatura}: ");
            double nota = Convert.ToDouble(Console.ReadLine()); // Leer nota
            Notas[asignatura] = nota; // Guardar nota en el diccionario
        }
    }

    //Método que imprime las notas introducidas
    public void MostrarNotas()
    {
        foreach (var asignatura in Notas.Keys)
        {
            Console.WriteLine($"En {asignatura} has sacado {Notas[asignatura]}");
        }
    }
}

class Program
{
    static void Main()
    {
        Curso curso = new Curso(); //Crear objeto curso
        curso.IngresarNotas(); //Solicitar notas al usuario
        curso.MostrarNotas(); //Mostrar notas
    }
}
