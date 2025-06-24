//Contar vocales en una palabra
using System;
using System.Collections.Generic;

//Clase que representa una palabra y permite contar vocales
class ContadorVocales
{
    public string Palabra { get; set; }

    //Convertir la palabra a minúsculas
    public ContadorVocales(string palabra)
    {
        Palabra = palabra.ToLower();
    }

    //Contar cuántas veces aparece cada vocal
    public Dictionary<char, int> ContarVocales()
    {
        //Diccionario para almacenar la cantidad de cada vocal
        Dictionary<char, int> conteo = new Dictionary<char, int>()
        {
            { 'a', 0 },
            { 'e', 0 },
            { 'i', 0 },
            { 'o', 0 },
            { 'u', 0 }
        };

        foreach (char c in Palabra)
        {
            if (conteo.ContainsKey(c))
            {
                conteo[c]++; 
            }
        }

        return conteo; //Devolver el diccionario con el conteo
    }
}

class Program
{
    static void Main()
    {
        //Solicitar la palabra al usuario
        Console.Write("Ingrese una palabra: ");
        string palabra = Console.ReadLine();

        //Crear la clase ContadorVocales
        ContadorVocales contador = new ContadorVocales(palabra);

        //Obtener los resultados del conteo
        var resultado = contador.ContarVocales();

        //Mostrar el resultado por pantalla
        Console.WriteLine("\nCantidad de vocales en la palabra:");
        foreach (var item in resultado)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}

