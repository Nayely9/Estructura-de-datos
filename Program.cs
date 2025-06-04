// Nombre: Nayely Tumbaco
// Fecha: 03/06/2025

using System;

namespace FigurasGeometricas
{
    // Clase para representar un Círculo
    public class Circulo
    {
        private double radio;  // Radio del círculo

        // Constructor que recibe el radio
        public Circulo(double radio)
        {
            this.radio = radio;
        }

        // Método que calcula el área del círculo
        public double CalcularArea()
        {
            return Math.PI * radio * radio;
        }

        // Método que calcula el perímetro del círculo
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }
    }

    // Clase para representar un Rectángulo
    public class Rectangulo
    {
        private double baseRect; // Base del rectángulo
        private double altura;   // Altura del rectángulo

        // Constructor que recibe base y altura
        public Rectangulo(double baseRect, double altura)
        {
            this.baseRect = baseRect;
            this.altura = altura;
        }

        // Método que calcula el área
        public double CalcularArea()
        {
            return baseRect * altura;
        }

        // Método que calcula el perímetro
        public double CalcularPerimetro()
        {
            return 2 * (baseRect + altura);
        }
    }

    // Clase principal del programa
    class Programa
    {
        static void Main(string[] args)
        {
            // Pedir al usuario el radio del círculo
            Console.WriteLine("Ingrese el radio del círculo:");
            double radio = Convert.ToDouble(Console.ReadLine());

            Circulo miCirculo = new Circulo(radio);
            Console.WriteLine("\n--- CÍRCULO ---");
            Console.WriteLine("Área: " + miCirculo.CalcularArea());
            Console.WriteLine("Perímetro: " + miCirculo.CalcularPerimetro());

            // Pedir al usuario la base y altura del rectángulo
            Console.WriteLine("\nIngrese la base del rectángulo:");
            double baseRect = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ingrese la altura del rectángulo:");
            double altura = Convert.ToDouble(Console.ReadLine());

            Rectangulo miRectangulo = new Rectangulo(baseRect, altura);
            Console.WriteLine("\n--- RECTÁNGULO ---");
            Console.WriteLine("Área: " + miRectangulo.CalcularArea());
            Console.WriteLine("Perímetro: " + miRectangulo.CalcularPerimetro());

            // Esperar a que el usuario presione una tecla antes de cerrar
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
