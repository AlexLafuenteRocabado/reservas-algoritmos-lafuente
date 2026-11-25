// Alex Lafuente Rocabado

// ---------- TU SOLUCIÓN: programación dinámica (mochila 0/1) ----------
// dp[i, w] = ganancia máxima usando los primeros i paquetes con capacidad w.
// Costo: O(n · C) en tiempo y espacio. EstaEnElViaje: O(1) con HashSet.
public sealed class PlanificadorMejorado : IPlanificador
{
    private readonly HashSet<string> _elegidos = new();

    public (int ganancia, List<string> codigos) Elegir(Paquete[] paquetes, int capacidadKg)
    {
        _elegidos.Clear();
        int n = paquetes.Length;

       .
        if (n == 0 || capacidadKg <= 0) return (0, new List<string>());

        var dp = new int[n + 1, capacidadKg + 1];   // fila 0 y columna 0 quedan en 0

        for (int i = 1; i <= n; i++)
        {
            var p = paquetes[i - 1];
            for (int w = 0; w <= capacidadKg; w++)
            {
                int mejor = dp[i - 1, w];                       
                if (p.Kg <= w)                                  
                {
                    int con = dp[i - 1, w - p.Kg] + p.Ganancia; 
                    if (con > mejor) mejor = con;
                }
                dp[i, w] = mejor;
            }
        }

        var codigos = new List<string>();
        int cap = capacidadKg;
        for (int i = n; i >= 1; i--)
        {
            if (dp[i, cap] != dp[i - 1, cap])
            {
                var p = paquetes[i - 1];
                codigos.Add(p.Codigo);
                _elegidos.Add(p.Codigo);
                cap -= p.Kg;
            }
        }

        return (dp[n, capacidadKg], codigos);
    }

    public bool EstaEnElViaje(string codigo) => _elegidos.Contains(codigo); 
}
