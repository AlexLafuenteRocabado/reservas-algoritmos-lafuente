
using System;
using System.Diagnostics;

class Program
{
    static void Burbuja(int[] a)
    {
        for (int i = 0; i < a.Length - 1; i++)
        {
            for (int j = 0; j < a.Length - i - 1; j++)
            {
                if (a[j] > a[j + 1])
                {
                    int temp = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = temp;
                }
            }
        }
    }

    static void MergeSort(int[] a)
    {
        if (a.Length <= 1) return;

        int medio = a.Length / 2;

        int[] izquierda = new int[medio];
        int[] derecha = new int[a.Length - medio];

        Array.Copy(a, 0, izquierda, 0, izquierda.Length);
        Array.Copy(a, medio, derecha, 0, derecha.Length);

        MergeSort(izquierda);
        MergeSort(derecha);

        int i = 0, j = 0, k = 0;

        while (i < izquierda.Length && j < derecha.Length)
        {
            if (izquierda[i] <= derecha[j])
                a[k++] = izquierda[i++];
            else
                a[k++] = derecha[j++];
        }

        while (i < izquierda.Length)
            a[k++] = izquierda[i++];

        while (j < derecha.Length)
            a[k++] = derecha[j++];
    }

    static void QuickSort(int[] a, int inicio, int fin)
    {
        if (inicio >= fin) return;

        int pivote = a[fin];
        int i = inicio - 1;

        for (int j = inicio; j < fin; j++)
        {
            if (a[j] <= pivote)
            {
                i++;
                (a[i], a[j]) = (a[j], a[i]);
            }
        }

        (a[i + 1], a[fin]) = (a[fin], a[i + 1]);

        int posicion = i + 1;

        QuickSort(a, inicio, posicion - 1);
        QuickSort(a, posicion + 1, fin);
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
        int[] cantidades = { 1000, 5000, 10000 };
        Random random = new Random(42);

        Console.WriteLine("TORNEO DE ORDENAMIENTOS");
        Console.WriteLine("Cantidad | Burbuja | MergeSort | QuickSort");
        
        foreach (int cantidad in cantidades)
        {
            int[] original = new int[cantidad];

            for (int i = 0; i < cantidad; i++)
                original[i] = random.Next(1, 100000);

            // Calentamiento con datos pequeños
            int[] calentamiento = { 8, 3, 6, 1, 9, 2 };
            Burbuja((int[])calentamiento.Clone());
            MergeSort((int[])calentamiento.Clone());

            int[] prueba = (int[])calentamiento.Clone();
            QuickSort(prueba, 0, prueba.Length - 1);

            double tiempoBurbuja = 0;
            double tiempoMerge = 0;
            double tiempoQuick = 0;

            // Tres repeticiones
            for (int r = 0; r < 3; r++)
            {
                int[] copia1 = (int[])original.Clone();
                int[] copia2 = (int[])original.Clone();
                int[] copia3 = (int[])original.Clone();

                tiempoBurbuja += Medir(() => Burbuja(copia1));
                tiempoMerge += Medir(() => MergeSort(copia2));
                tiempoQuick += Medir(() =>
                    QuickSort(copia3, 0, copia3.Length - 1));
            }

            Console.WriteLine(
                $"{cantidad} | " +
                $"{tiempoBurbuja / 3:F4} ms | " +
                $"{tiempoMerge / 3:F4} ms | " +
                $"{tiempoQuick / 3:F4} ms");
        }
    }
}
