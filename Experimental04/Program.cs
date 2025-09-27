using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace VuelosBaratos
{
    class Program
    {
        // Base de datos ficticia: origen -> lista de (destino, precio)
        static Dictionary<string, List<Tuple<string,int>>> vuelos = new Dictionary<string, List<Tuple<string,int>>>()
        {
            { "Quito", new List<Tuple<string,int>> { Tuple.Create("Guayaquil", 50), Tuple.Create("Cuenca", 40) } },
            { "Guayaquil", new List<Tuple<string,int>> { Tuple.Create("Quito", 50), Tuple.Create("Manta", 30) } },
            { "Cuenca", new List<Tuple<string,int>> { Tuple.Create("Quito", 40), Tuple.Create("Loja", 25) } },
            { "Manta", new List<Tuple<string,int>> { Tuple.Create("Guayaquil", 30), Tuple.Create("Loja", 35) } },
            { "Loja", new List<Tuple<string,int>> { Tuple.Create("Cuenca", 25), Tuple.Create("Manta", 35) } }
        };

        static void MostrarVuelos()
        {
            Console.WriteLine("=== Vuelos disponibles ===");
            foreach (var kv in vuelos)
            {
                Console.WriteLine($"Desde {kv.Key}:");
                foreach (var t in kv.Value)
                {
                    Console.WriteLine($"   -> {t.Item1} (${t.Item2})");
                }
            }
            Console.WriteLine("==========================\n");
        }

        // Algoritmo tipo Dijkstra con cola simple (lista ordenada por costo)
        static (List<string> camino, int costo, double tiempoMs) VueloBarato(string origen, string destino)
        {
            var sw = Stopwatch.StartNew();

            var queue = new List<Tuple<string,int>>(); // (ciudad, costoAcumulado)
            var dist = new Dictionary<string,int>();
            var prev = new Dictionary<string,string>();
            var visited = new HashSet<string>();

            dist[origen] = 0;
            queue.Add(Tuple.Create(origen, 0));

            while (queue.Count > 0)
            {
                // extraer elemento con menor costo
                queue.Sort((a,b) => a.Item2.CompareTo(b.Item2));
                var current = queue[0];
                queue.RemoveAt(0);

                string u = current.Item1;
                int costoActual = current.Item2;

                if (visited.Contains(u)) continue;
                visited.Add(u);

                if (u == destino) break;

                if (!vuelos.ContainsKey(u)) continue;

                foreach (var neighbor in vuelos[u])
                {
                    string v = neighbor.Item1;
                    int peso = neighbor.Item2;
                    if (visited.Contains(v)) continue;

                    int alt = costoActual + peso;
                    if (!dist.ContainsKey(v) || alt < dist[v])
                    {
                        dist[v] = alt;
                        prev[v] = u;
                        queue.Add(Tuple.Create(v, alt));
                    }
                }
            }

            // reconstruir camino
            if (!dist.ContainsKey(destino))
            {
                sw.Stop();
                return (null, -1, sw.Elapsed.TotalMilliseconds);
            }

            var path = new List<string>();
            string cur = destino;
            while (cur != null && cur != origen)
            {
                path.Add(cur);
                prev.TryGetValue(cur, out cur);
            }

            if (cur == origen)
            {
                path.Add(origen);
                path.Reverse();
                sw.Stop();
                return (path, dist[destino], sw.Elapsed.TotalMilliseconds);
            }
            else
            {
                sw.Stop();
                return (null, -1, sw.Elapsed.TotalMilliseconds);
            }
        }

        static void Main(string[] args)
        {
            MostrarVuelos();

            Console.WriteLine("Consulta de ruta más barata entre dos ciudades\n");
            Console.Write("Ingrese la ciudad de origen: ");
            string origen = Console.ReadLine().Trim();
            Console.Write("Ingrese la ciudad de destino: ");
            string destino = Console.ReadLine().Trim();

            // Buscar claves ignorando mayúsculas/minúsculas
            string origenKey = FindKeyIgnoreCase(origen);
            string destinoKey = FindKeyIgnoreCase(destino);

            if (origenKey == null || destinoKey == null)
            {
                Console.WriteLine("\n⚠️ Error: una de las ciudades no existe en la base de datos.");
                return;
            }

            var result = VueloBarato(origenKey, destinoKey);
            if (result.camino != null)
            {
                Console.WriteLine("\n=== Resultados de la búsqueda ===");
                Console.WriteLine("Ruta encontrada: " + string.Join(" → ", result.camino));
                Console.WriteLine("Costo total: " + result.costo + " USD");
                Console.WriteLine("Tiempo de ejecución: " + result.tiempoMs + " ms");
            }
            else
            {
                Console.WriteLine("\n⚠️ No existe una ruta entre esas ciudades.");
            }
        }

        static string FindKeyIgnoreCase(string input)
        {
            foreach (var k in vuelos.Keys)
            {
                if (string.Equals(k, input, StringComparison.OrdinalIgnoreCase))
                    return k;
            }
            return null;
        }
    }
}
