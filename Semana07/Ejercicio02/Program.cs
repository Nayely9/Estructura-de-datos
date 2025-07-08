using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    // Se crean tres pilas que representan las tres torres
    static Stack<int> origen = new Stack<int>();
    static Stack<int> auxiliar = new Stack<int>();
    static Stack<int> destino = new Stack<int>();

    /// <summary>
    /// Inicializa la torre origen con los discos en orden descendente.
    /// </summary>
    static void InicializarTorres(int numDiscos)
    {
        // El disco más grande se coloca al final 
        for (int i = numDiscos; i >= 1; i--)
        {
            origen.Push(i);
        }
    }

    /// <summary>
    /// Algoritmo recursivo para resolver las Torres
    /// Muestra cada paso de movimiento entre torres.
    /// </summary>
    /// <param name="n">Número de discos a mover</param>
    /// <param name="origen">Torre de origen</param>
    /// <param name="destino">Torre de destino</param>
    /// <param name="auxiliar">Torre auxiliar</param>
    /// <param name="nombreOrigen">Nombre de la torre de origen</param>
    /// <param name="nombreDestino">Nombre de la torre de destino</param>
    /// <param name="nombreAuxiliar">Nombre de la torre auxiliar</param>
    static void ResolverHanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar,
                              string nombreOrigen, string nombreDestino, string nombreAuxiliar)
    {
        // Caso base: si hay un solo disco, simplemente se mueve
        if (n == 1)
        {
            int disco = origen.Pop(); // Quita el disco del origen
            destino.Push(disco);      // Lo pone en el destino
            Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
            return;
        }

        // Mover n-1 discos al auxiliar
        ResolverHanoi(n - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino);

        // Mover el disco restante al destino
        ResolverHanoi(1, origen, destino, auxiliar, nombreOrigen, nombreDestino, nombreAuxiliar);

        // Mover los n-1 discos desde auxiliar al destino
        ResolverHanoi(n - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen);
    }

    static void Main()
    {
        Console.Write("Ingrese el número de discos: ");
        int numDiscos = int.Parse(Console.ReadLine());

        // Inicializa los discos en la torre de origen
        InicializarTorres(numDiscos);

        // Muestra los pasos para resolver el problema
        Console.WriteLine("Resolución paso a paso:");
        ResolverHanoi(numDiscos, origen, destino, auxiliar, "Origen", "Destino", "Auxiliar");
    }
}

