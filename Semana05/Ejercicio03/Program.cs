//Mostrar numeros ganadores de menor a mayor
using System;
using System.Collections.Generic;

//Clase que representa una lotería con una lista de números ganadores
class Loteria
{
    public List<int> Numeros { get; set; } = new List<int>();

    //Leer los 6 números de la lotería 
    public void LeerNumeros()
    {
        Console.WriteLine("Ingrese 6 números ganadores:");
        for (int i = 0; i < 6; i++)
        {
            Console.Write($"Número {i + 1}: ");
            Numeros.Add(int.Parse(Console.ReadLine()));
        }
    }

    //Ordenar los números de menor a mayor y mostrarlos
    public void MostrarOrdenados()
    {
        Numeros.Sort(); 
        Console.WriteLine("Números ganadores ordenados: " + string.Join(", ", Numeros));
    }
}

class Program
{
    static void Main()
    {
        Loteria loteria = new Loteria(); //Crear objeto
        loteria.LeerNumeros(); //Leer números del usuario
        loteria.MostrarOrdenados(); //Mostrar los numeros ordenados
    }
}
