//Mostrar la media ya la desviacion de una lista de números
using System;
using System.Collections.Generic;
using System.Linq; // Para usar funciones estadísticas como Average

//Clase que representa una muestra de datos y permite calcular estadísticas
class Estadistica
{
    public List<double> Muestra { get; set; }

    //Recibe la cadena del usuario y convierte a lista de números
    public Estadistica(string datos)
    {
        //Separa por comas, eliminar espacios y convertir a lista 
        Muestra = new List<double>();
        var partes = datos.Split(',');

        foreach (var parte in partes)
        {
            if (double.TryParse(parte.Trim(), out double numero))
            {
                Muestra.Add(numero);
            }
        }
    }

    //Calcular la media
    public double CalcularMedia()
    {
        return Muestra.Average();
    }

    //Calcular la desviación estándar
    public double CalcularDesviacionTipica()
    {
        double media = CalcularMedia();
        double sumaCuadrados = 0;

        foreach (var numero in Muestra)
        {
            sumaCuadrados += Math.Pow(numero - media, 2);
        }

        double varianza = sumaCuadrados / Muestra.Count;
        return Math.Sqrt(varianza); //Raíz cuadrada
    }
}

class Program
{
    static void Main()
    {
        //Solicitar los datos al usuario
        Console.Write("Ingrese los números separados por comas: ");
        string entrada = Console.ReadLine();

        //Crear la muestra
        Estadistica estadistica = new Estadistica(entrada);

        //Mostrar los resultados
        Console.WriteLine($"\nMedia: {estadistica.CalcularMedia():F2}");
        Console.WriteLine($"Desviación típica: {estadistica.CalcularDesviacionTipica():F2}");
    }
}
