using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // 1. Crear conjunto de 500 ciudadanos
        HashSet<string> todosCiudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            todosCiudadanos.Add($"Ciudadano {i}");
        }

        // 2. Crear conjuntos de vacunados (sin que se repitan entre sí)
        HashSet<string> pfizer = new HashSet<string>();
        HashSet<string> astrazeneca = new HashSet<string>();
        Random rnd = new Random();

        // Seleccionar 75 ciudadanos aleatorios para Pfizer
        List<string> listaTodos = todosCiudadanos.ToList();
        while (pfizer.Count < 75)
        {
            int index = rnd.Next(listaTodos.Count);
            pfizer.Add(listaTodos[index]);
        }

        // Seleccionar 75 ciudadanos aleatorios para AstraZeneca sin repetir los de Pfizer
        List<string> restantes = listaTodos.Except(pfizer).ToList();
        while (astrazeneca.Count < 75)
        {
            int index = rnd.Next(restantes.Count);
            astrazeneca.Add(restantes[index]);
        }

        // 3. Operaciones de teoría de conjuntos
        var noVacunados = todosCiudadanos.Except(pfizer.Union(astrazeneca)).ToList();
        var ambasDosis = pfizer.Intersect(astrazeneca).ToList(); // Será 0 porque no hay duplicados
        var soloPfizer = pfizer.Except(astrazeneca).ToList();
        var soloAstra = astrazeneca.Except(pfizer).ToList();

        // 4. Mostrar resultados
        Console.WriteLine($"Ciudadanos no vacunados ({noVacunados.Count}): {string.Join(", ", noVacunados)}\n");
        Console.WriteLine($"Ciudadanos con ambas dosis ({ambasDosis.Count}): {string.Join(", ", ambasDosis)}\n");
        Console.WriteLine($"Ciudadanos solo Pfizer ({soloPfizer.Count}): {string.Join(", ", soloPfizer)}\n");
        Console.WriteLine($"Ciudadanos solo AstraZeneca ({soloAstra.Count}): {string.Join(", ", soloAstra)}\n");
    }
}
