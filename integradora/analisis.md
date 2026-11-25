Alex Lafuente Rocabado

I1 — Análisis y elección de estrategia

a) Costo de PlanificadorIngenuo.Elegir
El ciclo externo recorre todas las máscaras: 2^n subconjuntos. Por cada una, el ciclo interno recorre los n paquetes para sumar kg y ganancia: O(n).
Reconstruir la lista final cuesta O(n) una sola vez.
Costo: O(n · 2^n)(exponencial).

b) T(n) = 2T(n-1) + 1 y el teorema maestro de bolsillo
El teorema maestro de bolsillo sirve para T(n) = a·T(n/b) + O(n^k), es decir, cuando el problema se DIVIDE entre b en cada llamada. Aquí el tamaño solo
se RESTA (n → n-1), no se divide, así que no tiene la forma requerida.
Se resuelve por expansión:
T(n) = 2T(n-1)+1 = 4T(n-2)+2+1 = ... = 2^n·T(0) + (2^n - 1)
Costo: O(2^n) (el árbol de decisiones tiene 2^n hojas).

c) ¿Sirve un voraz por ganancia/kg?
No. Caso 1 de las pruebas: P1 (10 kg, 60 Bs), P2 (20 kg, 100 Bs),
P3 (30 kg, 120 Bs), capacidad 50 kg.
Razones: P1 = 6, P2 = 5, P3 = 4 Bs/kg.
- Voraz: toma P1 (10 kg) y P2 (30 kg acumulados) → 160 Bs; P3 ya no cabe
  (60 kg > 50). Resultado: 160 Bs.
- Óptimo: P2 + P3 = 50 kg → 220 Bs.
El voraz se equivoca porque un paquete no se puede fraccionar: la mejor
razón local deja espacio desperdiciado.

Estrategia elegida: programación dinámica (mochila 0/1).
dp[i][w] = ganancia máxima usando los primeros i paquetes con capacidad w.
- dp[i][w] = dp[i-1][w]                                  si kg_i > w
- dp[i][w] = max(dp[i-1][w], dp[i-1][w-kg_i] + ganancia_i)  si kg_i <= w
- dp[0][w] = 0 y dp[i][0] = 0.
Por qué funciona (qué se repite): la recursión «llevo / no llevo» vuelve a
resolver los mismos subproblemas (i, w) muchas veces; hay solo n·(C+1)
distintos, y se calculan una vez y se guardan (subproblemas superpuestos +
subestructura óptima: la mejor solución para (i, w) usa la mejor de
(i-1, algo)).
Reconstrucción: desde (n, C) hacia atrás; si dp[i][w] != dp[i-1][w], el
paquete i va, y w -= kg_i. Con óptimo único no hay ambigüedad.
Costo: O(n · C) en tiempo y espacio (más O(n) para reconstruir), donde
C es la capacidad. Es pseudo-polinomial: depende del valor de C, no solo de n.

d) Estructura para EstaEnElViaje
Un HashSet<string> con los códigos elegidos, llenado al final de Elegir
(se limpia en cada llamada a Elegir).
- Construcción: O(k), con k paquetes elegidos.
- Consulta: O(1) esperado.
Recorrer la lista cuesta O(k) por consulta; con q consultas (miles): O(q·k) contra O(q) con el HashSet.
