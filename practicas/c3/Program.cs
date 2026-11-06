
using System;
using System.Diagnostics;

class Program
{
    // Busqueda lineal
    static bool BusquedaLineal(int[] lista, int buscando)
    {
        foreach (int x in lista)
        {
            if (x == buscando)
                return true;
        }

        return false;
    }

    static double MedirTiempo(int[] lista, int buscando)
    {
        Stopwatch reloj = Stopwatch.StartNew();

        BusquedaLineal(lista, buscando);

        reloj.Stop();

        return reloj.Elapsed.TotalMilliseconds;
    }

    static void Main()
    {
        int n = 1000000;

        int[] tamanos = { n, 4 * n, 16 * n };

        Console.WriteLine("TABLA DE MEDICIONES - BUSQUEDA LINEAL");
        Console.WriteLine("--------------------------------------");

        foreach (int tamano in tamanos)
        {
            int[] lista = new int[tamano];

            // Llenar el arreglo
            for (int i = 0; i < tamano; i++)
            {
                lista[i] = i;
            }

            // Buscar un elemento inexistente
            // Esto obliga a recorrer toda la lista.

            int buscando = -1;

            // Calentamiento
            BusquedaLineal(lista, buscando);

            double suma = 0;

            Console.WriteLine("\nTamaño: " + tamano);

            // Cinco corridas
            for (int i = 1; i <= 5; i++)
            {
                double tiempo = MedirTiempo(lista, buscando);

                suma += tiempo;

                Console.WriteLine(
                    "Corrida " + i + ": " +
                    tiempo.ToString("F4") + " ms"
                );
            }

            double promedio = suma / 5;

            Console.WriteLine(
                "PROMEDIO: " + promedio.ToString("F4") + " ms"
            );
        }
    }
}
