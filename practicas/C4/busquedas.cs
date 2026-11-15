
using System;
using System.Diagnostics;
using System.Linq;

class Program
{
    static bool BusquedaLineal(int[] datos, int buscado)
    {
        foreach (int numero in datos)
        {
            if (numero == buscado)
                return true;
        }
        return false;
    }

    static bool BusquedaBinaria(int[] datos, int buscado)
    {
        int inicio = 0;
        int fin = datos.Length - 1;

        while (inicio <= fin)
        {
            int medio = inicio + (fin - inicio) / 2;

            if (datos[medio] == buscado)
                return true;

            if (datos[medio] < buscado)
                inicio = medio + 1;
            else
                fin = medio - 1;
        }

        return false;
    }

    static double Medir(Action accion)
    {
        Stopwatch reloj = Stopwatch.StartNew();
        accion();
        reloj.Stop();

        return reloj.Elapsed.TotalMilliseconds;
    }

    static void Main()
    {
        int[] datos = Enumerable.Range(1, 1000000).ToArray();
        int buscado = 1000000;

        // Calentamiento
        BusquedaLineal(datos, buscado);
        BusquedaBinaria(datos, buscado);

        double totalLineal = 0;
        double totalBinaria = 0;

        // Tres mediciones
        for (int i = 1; i <= 3; i++)
        {
            totalLineal += Medir(() =>
                BusquedaLineal(datos, buscado));

            totalBinaria += Medir(() =>
                BusquedaBinaria(datos, buscado));
        }

        double promedioLineal = totalLineal / 3;
        double promedioBinaria = totalBinaria / 3;

        Console.WriteLine("COMPARACION DE BUSQUEDAS");
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"Busqueda Lineal: {promedioLineal:F6} ms");
        Console.WriteLine($"Busqueda Binaria: {promedioBinaria:F6} ms");

        Console.WriteLine($"Cociente Lineal/Binaria: " +
            $"{promedioLineal / promedioBinaria:F2} veces");
    }
}
