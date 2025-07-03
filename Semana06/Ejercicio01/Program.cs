using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear la lista enlazada y llenarla con 50 números aleatorios del 1 al 999
        LinkedList<int> lista = new LinkedList<int>();
        Random rnd = new Random();

        for (int i = 0; i < 50; i++)
        {
            lista.AddLast(rnd.Next(1, 1000)); // 1000 no se incluye
        }

        // Mostrar la lista original
        Console.WriteLine("Lista original:");
        MostrarLista(lista);

        // Leer el rango desde el teclado
        Console.Write("Ingrese el valor mínimo del rango: ");
        int min = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el valor máximo del rango: ");
        int max = int.Parse(Console.ReadLine());

        // Eliminar los nodos que estén fuera del rango
        LinkedListNode<int> actual = lista.First;
        while (actual != null)
        {
            LinkedListNode<int> siguiente = actual.Next;
            if (actual.Value < min || actual.Value > max)
            {
                lista.Remove(actual);
            }
            actual = siguiente;
        }

        // Mostrar la lista final
        Console.WriteLine("\nLista después de eliminar los nodos fuera del rango:");
        MostrarLista(lista);
    }

    static void MostrarLista(LinkedList<int> lista)
    {
        foreach (int valor in lista)
        {
            Console.Write(valor + " ");
        }
        Console.WriteLine();
    }
}