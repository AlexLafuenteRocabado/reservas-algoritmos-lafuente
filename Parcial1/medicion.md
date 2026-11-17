using System.Collections.Generic;
using System.Diagnostics;

namespace Parcial1.VarianteA;

public static class Registro
{
    // Solución ACTUAL (lenta): comparar cada carnet con todos los que le siguen.
    public static bool HayRepetidosPorPares(int[] carnets)
    {
        for (int i = 0; i < carnets.Length; i++)
            for (int j = i + 1; j < carnets.Length; j++)
                if (carnets[i] == carnets[j]) return true;
        return false;
    }

    // TU CURA: recorre el arreglo una sola vez guardando lo ya visto en un HashSet.
    // Si Add devuelve false, ese carnet ya estaba -> hay repetido.
    // Costo: O(n) (promedio). No modifica el arreglo recibido.
    public static bool HayRepetidosCurado(int[] carnets)
    {
        var vistos = new HashSet<int>();
        foreach (int c in carnets)
        {
            if (!vistos.Add(c)) return true;
        }
        return false;
    }

    public static int[] GenerarSinRepetidos(int n, int semilla = 42)
    {
        var datos = new int[n];
        for (int i = 0; i < n; i++) datos[i] = i;
        var azar = new Random(semilla);
        for (int i = n - 1; i > 0; i--)
        {
            int k = azar.Next(i + 1);
            (datos[i], datos[k]) = (datos[k], datos[i]);
        }
        return datos;
    }
}

public static class Medicion
{
    static double PromedioMs(Func<int[], bool> f, int[] datos)
    {
        f(datos);
        double suma = 0;
        for (int k = 0; k < 3; k++)
        {
            var sw = Stopwatch.StartNew();
            f(datos);
            sw.Stop();
            suma += sw.Elapsed.TotalMilliseconds;
        }
        return suma / 3.0;
    }

    public static void Ejecutar(int n = 10_000)
    {
        Console.WriteLine();
        Console.WriteLine("| n | Por pares (ms) | x vs fila anterior | Curado (ms) | x vs fila anterior |");
        Console.WriteLine("|---|---|---|---|---|");

        double? pPrev = null, cPrev = null;
        for (int m = 1; m <= 8; m *= 2)
        {
            int tam = n * m;
            var datos = Registro.GenerarSinRepetidos(tam);

            double p = PromedioMs(Registro.HayRepetidosPorPares, datos);
            double c = PromedioMs(Registro.HayRepetidosCurado, datos);

            string rp = pPrev.HasValue ? (p / pPrev.Value).ToString("F2") : "-";
            string rc = cPrev.HasValue ? (c / cPrev.Value).ToString("F2") : "-";

            Console.WriteLine($"| {tam} | {p:F2} | {rp} | {c:F4} | {rc} |");
            pPrev = p; cPrev = c;
        }
    }
}

public static class Programa
{
    private static readonly (int[] datos, bool esperado, string que)[] Casos =
    {
        (new[] { 7, 3, 9, 3, 5 },   true,  "repetido en el medio"),
        (new[] { 7, 3, 9, 4, 5 },   false, "sin repetidos"),
        (new int[] { },             false, "lista vacía"),
        (new[] { 8 },               false, "un solo elemento"),
        (new[] { 4, 1, 2, 6, 4 },   true,  "repetido en los extremos"),
    };

    public static void Main()
    {
        foreach (var (datos, esperado, que) in Casos)
        {
            bool lenta = Registro.HayRepetidosPorPares(datos);
            string curada;
            try { curada = Registro.HayRepetidosCurado(datos).ToString(); }
            catch (NotImplementedException) { curada = "(sin escribir)"; }
            Console.WriteLine($"{que,-26} esperado {esperado,-5} · por pares {lenta,-5} · tu cura {curada}");
        }
        Medicion.Ejecutar(10_000);
    }
}

prueba 1
| n | Por pares (ms) | x vs fila anterior | Curado (ms) | x vs fila anterior |
|---|---|---|---|---|
| 10000 | 122,33 | - | 0,2432 | - |
| 20000 | 474,48 | 3,88 | 1,0770 | 4,43 |
| 40000 | 1817,61 | 3,83 | 1,1136 | 1,03 |
| 80000 | 7254,85 | 3,99 | 2,3991 | 2,15 |

prueba 2
| n | Por pares (ms) | x vs fila anterior | Curado (ms) | x vs fila anterior |
|---|---|---|---|---|
| 10000 | 123,44 | - | 0,3370 | - |
| 20000 | 503,42 | 4,08 | 1,3185 | 3,91 |
| 40000 | 1834,74 | 3,64 | 0,9558 | 0,72 |
| 80000 | 7234,64 | 3,94 | 2,7496 | 2,88 |
prueba 3 
| n | Por pares (ms) | x vs fila anterior | Curado (ms) | x vs fila anterior |
|---|---|---|---|---|
| 10000 | 117,70 | - | 0,2236 | - |
| 20000 | 451,81 | 3,84 | 1,1122 | 4,97 |
| 40000 | 1840,15 | 4,07 | 1,0880 | 0,98 |
| 80000 | 7281,00 | 3,96 | 2,5793 | 2,37 |
