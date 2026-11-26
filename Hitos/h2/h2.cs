using System;
using System.Collections.Generic;
using System.Diagnostics;

// H2 - Medicion: buscar un equipo por codigo
// Mismo problema, dos estructuras:
//   ingenua : List<Equipo>        -> recorre todo hasta encontrar (O(n))
//   adecuada: Dictionary<string, Equipo> (tabla hash) -> O(1) promedio

class Equipo
{
    public string Codigo;
    public string Marca;
    public decimal Precio;
    public bool Seminuevo;
}

class Program
{
    const int Consultas = 2000;   
    const int Corridas = 3;

    static Equipo[] Generar(int n)
    {
        string[] marcas = { "HP", "Dell", "Lenovo", "Asus", "Acer" };
        var rnd = new Random(42);
        var equipos = new Equipo[n];
        for (int i = 0; i < n; i++)
        {
            equipos[i] = new Equipo
            {
                Codigo = "EQ-" + i.ToString("D7"),
                Marca = marcas[rnd.Next(marcas.Length)],
                Precio = rnd.Next(2000, 12000),
                Seminuevo = rnd.Next(2) == 0
            };
        }
        return equipos;
    }

    static int BuscarEnLista(List<Equipo> lista, string[] codigos)
    {
        int encontrados = 0;
        foreach (string c in codigos)
        {
            foreach (Equipo e in lista)
            {
                if (e.Codigo == c) { encontrados++; break; }
            }
        }
        return encontrados;
    }

    static int BuscarEnDiccionario(Dictionary<string, Equipo> dic, string[] codigos)
    {
        int encontrados = 0;
        foreach (string c in codigos)
        {
            if (dic.TryGetValue(c, out Equipo e)) encontrados++;
        }
        return encontrados;
    }

    static double Medir(Func<int> accion, out int resultado)
    {
        var reloj = Stopwatch.StartNew();
        resultado = accion();
        reloj.Stop();
        return reloj.Elapsed.TotalMilliseconds;
    }

    static void Main()
    {
        int[] tamanos = { 10000, 20000, 40000, 80000 };

        Console.WriteLine("BUSCAR EQUIPO POR CODIGO (" + Consultas + " consultas)");
        Console.WriteLine("n        List (ms)    Dictionary (ms)   x");
        Console.WriteLine("-------------------------------------------");

        foreach (int n in tamanos)
        {
            Equipo[] datos = Generar(n);
            var lista = new List<Equipo>(datos);
            var dic = new Dictionary<string, Equipo>();
            foreach (Equipo e in datos) dic[e.Codigo] = e;


            var rnd = new Random(7);
            string[] codigos = new string[Consultas];
            for (int i = 0; i < Consultas; i++)
                codigos[i] = datos[rnd.Next(n)].Codigo;

            BuscarEnLista(lista, codigos);
            BuscarEnDiccionario(dic, codigos);

            double totalLista = 0, totalDic = 0;
            int resLista = 0, resDic = 0;

            for (int i = 0; i < Corridas; i++)
            {
                totalLista += Medir(() => BuscarEnLista(lista, codigos), out resLista);
                totalDic += Medir(() => BuscarEnDiccionario(dic, codigos), out resDic);
            }

            if (resLista != resDic || resLista != Consultas)
            {
                Console.WriteLine("ERROR: resultados distintos en n=" + n);
                return;
            }

            double promLista = totalLista / Corridas;
            double promDic = totalDic / Corridas;
            Console.WriteLine($"{n,-8} {promLista,10:F2}   {promDic,14:F4}   {promLista / promDic:F0}");
        }
    }
}
