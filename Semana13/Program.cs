using System;
using System.Collections.Generic;

namespace CatalogoRevistas
{
    class Program
    {
        // Lista que actúa como catálogo de revistas
        static List<string> catalogo = new List<string>
        {
            "National Geographic",
            "Time",
            "Forbes",
            "Scientific American",
            "Reader's Digest",
            "Nature",
            "The Economist",
            "Popular Mechanics",
            "Wired",
            "Sports Illustrated"
        };

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Catálogo de Revistas ===");
                Console.WriteLine("1. Buscar revista (Iterativa)");
                Console.WriteLine("2. Buscar revista (Recursiva)");
                Console.WriteLine("3. Mostrar catálogo completo");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                // Validar la opción ingresada
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción inválida. Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        BuscarIterativo();
                        break;
                    case 2:
                        BuscarRecursivo();
                        break;
                    case 3:
                        MostrarCatalogo();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }

        // Método de búsqueda iterativa
        static void BuscarIterativo()
        {
            Console.Write("\nIngrese el título a buscar: ");
            string titulo = Console.ReadLine();

            bool encontrado = false;
            foreach (string revista in catalogo)
            {
                if (revista.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    encontrado = true;
                    break;
                }
            }

            Console.WriteLine(encontrado ? "Encontrado" : "No encontrado");
        }

        // Método de búsqueda recursiva
        static void BuscarRecursivo()
        {
            Console.Write("\nIngrese el título a buscar: ");
            string titulo = Console.ReadLine();

            bool encontrado = BuscarRecursivoHelper(titulo, 0);
            Console.WriteLine(encontrado ? "Encontrado" : "No encontrado");
        }

        // Función auxiliar recursiva
        static bool BuscarRecursivoHelper(string titulo, int indice)
        {
            // Caso base: llegamos al final de la lista
            if (indice >= catalogo.Count)
                return false;

            // Verificamos el elemento actual
            if (catalogo[indice].Equals(titulo, StringComparison.OrdinalIgnoreCase))
                return true;

            // Llamada recursiva al siguiente índice
            return BuscarRecursivoHelper(titulo, indice + 1);
        }

        // Mostrar catálogo completo
        static void MostrarCatalogo()
        {
            Console.WriteLine("\nCatálogo de Revistas:");
            foreach (var revista in catalogo)
            {
                Console.WriteLine("- " + revista);
            }
        }
    }
}
