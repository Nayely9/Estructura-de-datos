using System;
using System.Collections.Generic;

class Traductor
{
    static void Main(string[] args)
    {
        // Diccionario base Español -> Inglés
        Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"tiempo", "time"},
            {"persona", "person"},
            {"año", "year"},
            {"camino", "way"},
            {"forma", "way"},
            {"día", "day"},
            {"cosa", "thing"},
            {"hombre", "man"},
            {"mundo", "world"},
            {"vida", "life"},
            {"mano", "hand"},
            {"parte", "part"},
            {"niño", "child"},
            {"niña", "child"},
            {"ojo", "eye"},
            {"mujer", "woman"},
            {"lugar", "place"},
            {"trabajo", "work"},
            {"semana", "week"},
            {"caso", "case"},
            {"punto", "point"},
            {"tema", "point"},
            {"gobierno", "government"},
            {"empresa", "company"},
            {"compañía", "company"}
        };

        int opcion;
        do
        {
            Console.WriteLine("\n==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    TraducirFrase(diccionario);
                    break;
                case 2:
                    AgregarPalabra(diccionario);
                    break;
                case 0:
                    Console.WriteLine("Saliendo del traductor...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }

        } while (opcion != 0);
    }

    static void TraducirFrase(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngrese una frase en español: ");
        string frase = Console.ReadLine();

        string[] palabras = frase.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.None);

        Console.WriteLine("\nTraducción parcial: ");
        foreach (var palabra in palabras)
        {
            if (string.IsNullOrWhiteSpace(palabra))
                continue;

            string palabraLimpia = palabra.ToLower();

            if (diccionario.ContainsKey(palabraLimpia))
            {
                // Reemplazo manteniendo mayúscula inicial si corresponde
                string traduccion = diccionario[palabraLimpia];
                if (char.IsUpper(palabra[0]))
                {
                    traduccion = char.ToUpper(traduccion[0]) + traduccion.Substring(1);
                }
                Console.WriteLine($" - {palabra} => {traduccion}");
            }
            else
            {
                Console.WriteLine($" - {palabra} => [sin traducción]");
            }
        }
    }

    static void AgregarPalabra(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngrese la palabra en español: ");
        string espanol = Console.ReadLine();

        Console.Write("Ingrese la traducción en inglés: ");
        string ingles = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(espanol) && !string.IsNullOrWhiteSpace(ingles))
        {
            diccionario[espanol] = ingles;
            Console.WriteLine("Palabra agregada exitosamente.");
        }
        else
        {
            Console.WriteLine("Entrada no válida. Intente de nuevo.");
        }
    }
}