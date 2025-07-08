using System;
using System.Collections.Generic;

class BalanceChecker
{
    /// <summary>
    /// Verifica si una expresión contiene paréntesis, llaves y corchetes balanceados.
    /// </summary>
    public static bool EstaBalanceado(string expresion)
    {
        Stack<char> pila = new Stack<char>(); // Se crea una pila para almacenar los símbolos de apertura

        foreach (char c in expresion)
        {
            // Si el carácter es un símbolo de apertura, se agrega a la pila
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);
            }
            // Si es un símbolo de cierre, se verifica si hay un par correspondiente
            else if (c == ')' || c == '}' || c == ']')
            {
                if (pila.Count == 0) return false; // No hay símbolo de apertura para emparejar
                char tope = pila.Pop(); // Se saca el último símbolo de apertura
                if (!SimbolosCoinciden(tope, c)) return false; // Verificar si forman una pareja válida
            }
        }

        // Si la pila está vacía al final, todos los símbolos estuvieron balanceados
        return pila.Count == 0;
    }

    /// <summary>
    /// Comprueba si el símbolo de apertura y cierre coinciden correctamente.
    /// </summary>
    private static bool SimbolosCoinciden(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')') ||
               (apertura == '{' && cierre == '}') ||
               (apertura == '[' && cierre == ']');
    }

    static void Main()
    {
        // Solicitar al usuario que ingrese una expresión matemática
        Console.Write("Ingrese una expresión matemática: ");
        string expresion = Console.ReadLine();

        // Se llama a la función de verificación y se muestra el resultado
        if (EstaBalanceado(expresion))
            Console.WriteLine("Fórmula balanceada.");
        else
            Console.WriteLine("Fórmula no balanceada.");
    }
}
